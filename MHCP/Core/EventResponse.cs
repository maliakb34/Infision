using System;
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
        private readonly RegistryDevices _registry;
        private readonly ILogger<EventResponse> _logger;

        public EventResponse(RegistryDevices registry, ILogger<EventResponse> logger)
        {
            _registry = registry;
            _logger = logger;
        }

        public async Task RunAsync(
            RegisteredDevices device,
            NetworkStream stream,
            IEventResponseObserver? observer,
            CancellationToken ct = default)
        {
            var address = device.Address;
            while (!ct.IsCancellationRequested)
            {
                var (headerBytes, payload) = await MhcpWire.ReadFrameAsync(stream, ct).ConfigureAwait(false);
                var header = ProtocolHeader.Parse(headerBytes);
                if (header.MessageId > 1)
                    _logger.LogInformation(device.Address.ToString() + "   " + header.MessageId.ToString());
                switch (header.MessageId)
                {
                    case var msg when msg == MhcpConstants.REQ_HEART && header.RequestResponse == RequestResponseTypeEnum.Request:
                        observer?.OnHeartbeatRequested(device, header, payload);
                        break;

                    case var msg when msg == MhcpConstants.REQ_HEART_FREQ_SET && header.RequestResponse == RequestResponseTypeEnum.Response:
                        device.HeartbeatAcknowledged = true;
                        device.HandshakeCompleted = true;
                        device.Stream = stream;
                        _registry.TryUpdate(device);
                        observer?.OnHeartbeatFrequencyAcknowledged(device);
                        break;

                    case var msg when msg == MhcpConstants.REQ_DEVICE_INFO && header.RequestResponse == RequestResponseTypeEnum.Response:
                        device.HandshakeCompleted = true;
                        device.Stream = stream;
                        _registry.TryUpdate(device);
                        _logger.LogInformation("Device info payload received from {Device}:\n{Dump}",
                            device.Address,
                          ProtobufDumper.Dump(payload.ToArray().AsSpan()));
                        observer?.OnDeviceInfoReceived(device, payload);
                        break;

                    case var msg when msg == MhcpConstants.EVENT_INFUSION_CYCLE:
                        try
                        {
                            var infusionEvent = InfusionPeriodicEvent.Parse(payload.ToArray());
                            _logger.LogInformation(JsonSerializer.Serialize(infusionEvent));
                        }
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

    }

    public interface IEventResponseObserver
    {
        void OnHeartbeatRequested(RegisteredDevices device, ProtocolHeader requestHeader, ReadOnlyMemory<byte> payload);
        void OnHeartbeatFrequencyAcknowledged(RegisteredDevices device);
        void OnDeviceInfoReceived(RegisteredDevices device, ReadOnlyMemory<byte> payload);
    }
}
