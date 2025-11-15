using Infision;
using Infision.MHCP.Entities.Response;
using Infision.MHCP.Proto;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP.TCP
{
    public sealed class Organizator : IEventResponseObserver
    {
        private readonly RegistryDevices _registry;
        private readonly ConcurrentDictionary<string, ConnectionContext> _connections = new();
        private readonly ConcurrentDictionary<string, HandshakeWaiter> _handshakeWaiters = new();
        private readonly SemaphoreSlim _connectionLimiter;
        private readonly EventRequest _requestSender;
        private readonly EventResponse _responseProcessor;
        private readonly TimeSpan _handshakeTimeout;

        public Organizator(
            EventRequest requestSender,
            EventResponse responseProcessor,
            RegistryDevices registry,
            TimeSpan? handshakeTimeout = null)
        {
            _registry = registry;
            _connectionLimiter = new SemaphoreSlim(100, 100);
            _requestSender = requestSender;
            _responseProcessor = responseProcessor;
            _handshakeTimeout = handshakeTimeout ?? TimeSpan.FromSeconds(30);
        }

        public async Task HandleClientAsync(RegisteredDevices device, TcpClient client, CancellationToken parentToken)
        {
            await _connectionLimiter.WaitAsync(parentToken).ConfigureAwait(false);
            try
            {
                if (device.HandshakeCompleted)
                {
                    var context = await InitializeSessionAsync(device, client, parentToken).ConfigureAwait(false);
                    if (context is null)
                        return;

                    await WaitForResponseLoopAsync(device.Address, context).ConfigureAwait(false);
                }
                else
                {
                    await ImplantationAsync(device, parentToken, client).ConfigureAwait(false);
                }
            }
            finally
            {
                _connectionLimiter.Release();
            }
        }

        private async Task ImplantationAsync(RegisteredDevices device, CancellationToken parentToken, TcpClient? existingClient = null)
        {
            var address = device.Address;
            var client = existingClient ?? new TcpClient();

            if (existingClient is null)
            {
                if (!IPAddress.TryParse(address, out var ip))
                    throw new InvalidOperationException($"Invalid device IP: {address}");

                using var connectCts = CancellationTokenSource.CreateLinkedTokenSource(parentToken);
                await client.ConnectAsync(ip, device.Port, connectCts.Token).ConfigureAwait(false);
            }

            var context = await InitializeSessionAsync(device, client, parentToken).ConfigureAwait(false);
            if (context is null)
                return;

            try
            {
                await PerformHandshakeAsync(device.Address, context.Stream, parentToken).ConfigureAwait(false);
                await context.ResponseTask.ConfigureAwait(false);
            }
            finally
            {
                await CleanupAsync(device.Address).ConfigureAwait(false);
            }
        }

        private async Task<ConnectionContext?> InitializeSessionAsync(RegisteredDevices device, TcpClient client, CancellationToken parentToken)
        {
            var address = device.Address;
            var stream = client.GetStream();
            device.Stream = stream;
            device.HeartbeatAcknowledged = false;
            if (!device.HandshakeCompleted)
            {
                device.HandshakeCompleted = false;
            }

            _registry.TryUpdate(device);

            var responseCts = CancellationTokenSource.CreateLinkedTokenSource(parentToken);
            var responseTask = _responseProcessor.RunAsync(device, stream, this, responseCts.Token);
            var context = new ConnectionContext(client, stream, responseCts, responseTask);
            if (!_connections.TryAdd(address, context))
            {
                await context.DisposeAsync().ConfigureAwait(false);
                return null;
            }

            return context;
        }

        private async Task WaitForResponseLoopAsync(string address, ConnectionContext context)
        {
            try
            {
                await context.ResponseTask.ConfigureAwait(false);
            }
            finally
            {
                await CleanupAsync(address).ConfigureAwait(false);
            }
        }

        private async Task PerformHandshakeAsync(string address, NetworkStream stream, CancellationToken parentToken)
        {
            var waiter = _handshakeWaiters.GetOrAdd(address, _ => new HandshakeWaiter());
            try
            {
                await _requestSender.SendAsync(stream, MhcpConstants.REQ_HEART_FREQ_SET, parentToken).ConfigureAwait(false);
                await waiter.WaitForHeartbeatAsync(_handshakeTimeout, parentToken).ConfigureAwait(false);

                await _requestSender.SendAsync(stream, MhcpConstants.REQ_PERIODIC_INFUSION_INTERVAL, parentToken).ConfigureAwait(false);

                await _requestSender.SendAsync(stream, MhcpConstants.REQ_DEVICE_INFO, parentToken).ConfigureAwait(false);
                await waiter.WaitForDeviceInfoAsync(_handshakeTimeout, parentToken).ConfigureAwait(false);
            }
            finally
            {
                _handshakeWaiters.TryRemove(address, out _);
            }
        }

        private async Task CleanupAsync(string address)
        {
            if (_connections.TryRemove(address, out var ctx))
            {
                await ctx.DisposeAsync().ConfigureAwait(false);
            }

            if (_handshakeWaiters.TryRemove(address, out var waiter))
            {
                waiter.Cancel();
            }

            if (_registry.TryGet(address, out var device) && device is not null)
            {
                device.Stream = null;
                device.HeartbeatAcknowledged = false;
                _registry.TryUpdate(device);
            }
        }

        public void OnHeartbeatRequested(RegisteredDevices device, ProtocolHeader requestHeader, ReadOnlyMemory<byte> payload)
        {
            if (device.Stream is null)
                return;

            _ = _requestSender.SendResponseAsync(device.Stream, requestHeader, payload, CancellationToken.None);
        }

        public void OnHeartbeatFrequencyAcknowledged(RegisteredDevices device)
        {
            if (_handshakeWaiters.TryGetValue(device.Address, out var waiter))
            {
                waiter.SignalHeartbeat();
            }
        }

        public void OnDeviceInfoReceived(RegisteredDevices device, ReadOnlyMemory<byte> payload)
        {
            if (_handshakeWaiters.TryGetValue(device.Address, out var waiter))
            {
                waiter.SignalDeviceInfo();
            }
        }

        private sealed class ConnectionContext : IAsyncDisposable
        {
            private readonly TcpClient _client;
            private readonly NetworkStream _stream;
            private readonly CancellationTokenSource _responseCts;

            public ConnectionContext(TcpClient client, NetworkStream stream, CancellationTokenSource responseCts, Task responseTask)
            {
                _client = client;
                _stream = stream;
                _responseCts = responseCts;
                ResponseTask = responseTask;
            }

            public Task ResponseTask { get; }
            public NetworkStream Stream => _stream;

            public async ValueTask DisposeAsync()
            {
                try
                {
                    _responseCts.Cancel();
                }
                catch
                {
                }

                try
                {
                    await ResponseTask.ConfigureAwait(false);
                }
                catch
                {
                }

                _stream.Dispose();
                _client.Dispose();
                _responseCts.Dispose();
            }
        }

        private sealed class HandshakeWaiter
        {
            private readonly TaskCompletionSource<bool> _heartbeatTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
            private readonly TaskCompletionSource<bool> _deviceInfoTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

            public void SignalHeartbeat() => _heartbeatTcs.TrySetResult(true);
            public void SignalDeviceInfo() => _deviceInfoTcs.TrySetResult(true);

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
