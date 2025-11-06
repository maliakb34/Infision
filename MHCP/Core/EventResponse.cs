using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Infision.MHCP.Diagnostics;
using Infision.MHCP.Entities.Response;
using Infision.MHCP.Proto;
using Infision.MHCP.Types;
using Microsoft.Extensions.Logging;

namespace Infision.MHCP
{
    public sealed class EventResponse
    {
        private readonly IDiscoveryRegistry _registry;
        private readonly ILogger<EventResponse> _logger;

        private readonly ConcurrentDictionary<string, HandshakeTracker> _handshakes = new();

        public EventResponse(IDiscoveryRegistry registry, ILogger<EventResponse> logger)
        {
            _registry = registry;
            _logger = logger;
        }

        public async Task RunAsync(DiscoveredDevice device, NetworkStream stream, CancellationToken ct = default)
        {
            var address = device.Address;
            while (!ct.IsCancellationRequested)
            {
                var (headerBytes, payload) = await MhcpWire.ReadFrameAsync(stream, ct).ConfigureAwait(false);
                var header = ProtocolHeader.Parse(headerBytes);

                switch (header.MessageId)
                {
                    case var msg when msg == MhcpConstants.REQ_HEART && header.RequestResponse == RequestResponseTypeEnum.Request:
                        await ReplyHeartbeatAsync(stream, header, ct).ConfigureAwait(false);
                        break;

                    case var msg when msg == MhcpConstants.REQ_HEART_FREQ_SET && header.RequestResponse == RequestResponseTypeEnum.Response:
                        device.HeartbeatAcknowledged = true;
                        device.Stream = stream;
                        _registry.TryUpdate(device);
                        if (_handshakes.TryGetValue(address, out var tracker))
                        {
                            tracker.SignalHeartbeat();
                        }
                        break;

                    case var msg when msg == MhcpConstants.REQ_DEVICE_INFO && header.RequestResponse == RequestResponseTypeEnum.Response:
                        device.HandshakeCompleted = true;
                        device.Stream = stream;
                        _registry.TryUpdate(device);
                        _logger.LogInformation("Device info payload received from {Device}:\n{Dump}",
                            device.Address,
       ProtobufDumper.Dump(payload.ToArray().AsSpan()));
                        if (_handshakes.TryGetValue(address, out var deviceTracker))
                        {
                            deviceTracker.SignalDeviceInfo();
                        }
                        break;

                    case var msg when msg == MhcpConstants.EVENT_INFUSION_CYCLE:
                        try
                        {
                            var infusionEvent = InfusionPeriodicEvent.Parse(payload.ToArray());
                            _logger.LogInformation(JsonSerializer.Serialize(infusionEvent));  }
                        catch (Exception ex)
                        {
                            _logger.LogWarning(ex, "Failed to parse infusion cycle payload from {Device}", device.Address);
                        }
                        break;

                    default:
                        // Future: add more cases (patient info, events, etc.)
                        break;
                }
            }
        }

        public bool BeginHandshakeTracking(string address)
        {
            return _handshakes.TryAdd(address, new HandshakeTracker());
        }

        public void EndHandshakeTracking(string address)
        {
            if (_handshakes.TryRemove(address, out var tracker))
            {
                tracker.Cancel();
            }
        }

        public Task WaitForHeartbeatAsync(string address, TimeSpan timeout, CancellationToken ct)
        {
            if (!_handshakes.TryGetValue(address, out var tracker))
                throw new InvalidOperationException($"No handshake tracker registered for {address}");

            return tracker.WaitForHeartbeatAsync(timeout, ct);
        }

        public Task WaitForDeviceInfoAsync(string address, TimeSpan timeout, CancellationToken ct)
        {
            if (!_handshakes.TryGetValue(address, out var tracker))
                throw new InvalidOperationException($"No handshake tracker registered for {address}");

            return tracker.WaitForDeviceInfoAsync(timeout, ct);
        }

        private static async Task ReplyHeartbeatAsync(NetworkStream stream, ProtocolHeader requestHeader, CancellationToken ct)
        {
            var responseHeader = new ProtocolHeader
            {
                RouteId = requestHeader.RouteId,
                MessageId = requestHeader.MessageId,
                CategoryId = requestHeader.CategoryId,
                RequestResponse = RequestResponseTypeEnum.Response,
                SequenceNumber = requestHeader.SequenceNumber
            }.ToByteArray();

            var frame = MhcpWire.Build(responseHeader, Array.Empty<byte>());
            await stream.WriteAsync(frame, ct).ConfigureAwait(false);
        }

        private sealed class HandshakeTracker
        {
            private readonly TaskCompletionSource<bool> _heartbeatTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
            private readonly TaskCompletionSource<bool> _deviceInfoTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

            public void SignalHeartbeat()
            {
                _heartbeatTcs.TrySetResult(true);
            }

            public void SignalDeviceInfo()
            {
                _deviceInfoTcs.TrySetResult(true);
            }

            public void Cancel()
            {
                _heartbeatTcs.TrySetCanceled();
                _deviceInfoTcs.TrySetCanceled();
            }

            public async Task WaitForHeartbeatAsync(TimeSpan timeout, CancellationToken ct)
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                var delayTask = Task.Delay(timeout, cts.Token);
                var completed = await Task.WhenAny(_heartbeatTcs.Task, delayTask).ConfigureAwait(false);
                if (completed == delayTask)
                {
                    throw new TimeoutException("Heartbeat acknowledgement timed out.");
                }
                cts.Cancel();
                await _heartbeatTcs.Task.ConfigureAwait(false);
            }

            public async Task WaitForDeviceInfoAsync(TimeSpan timeout, CancellationToken ct)
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                var delayTask = Task.Delay(timeout, cts.Token);
                var completed = await Task.WhenAny(_deviceInfoTcs.Task, delayTask).ConfigureAwait(false);
                if (completed == delayTask)
                {
                    throw new TimeoutException("Device info response timed out.");
                }
                cts.Cancel();
                await _deviceInfoTcs.Task.ConfigureAwait(false);
            }
        }
    }
}
