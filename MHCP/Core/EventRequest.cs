using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Infision.MHCP.Entities;
using Infision.MHCP.Proto;
using Infision.MHCP.Types;
using Infision.MHCP.Entities;
using Microsoft.Extensions.Logging;
using Infision.MHCP.Entities.Request;


namespace Infision.MHCP
{
    public sealed class EventRequest
    {
        private readonly int _defaultHeartbeatSeconds;
        private readonly ILogger<EventRequest>? _logger;

        public EventRequest(int defaultHeartbeatSeconds = 1, ILogger<EventRequest>? logger = null)
        {
            _defaultHeartbeatSeconds = defaultHeartbeatSeconds;
            _logger = logger;
        }

        public Task SendAsync(NetworkStream stream, int messageId, CancellationToken ct = default)
            => SendAsync(stream, messageId, routeId: 0, payload: ReadOnlyMemory<byte>.Empty, ct);

        public async Task SendAsync(NetworkStream stream, int messageId, uint routeId, ReadOnlyMemory<byte> payload, CancellationToken ct = default)
        {
            var actualPayload = payload.Length > 0 ? payload : BuildPayload(messageId);

            var header = new ProtocolHeader
            {
                RouteId = routeId,
                MessageId = (uint)messageId,
                CategoryId = MhcpConstants.CATEGORY_REQUEST_RESPONSE,
                RequestResponse = RequestResponseTypeEnum.Request,
                SequenceNumber = (uint)MhcpWire.NextSeq()
            }.ToByteArray();

            var frame = MhcpWire.Build(header, actualPayload.ToArray());
            await stream.WriteAsync(frame, ct).ConfigureAwait(false);
        }

        public Task SendResponseAsync(NetworkStream stream, ProtocolHeader requestHeader, ReadOnlyMemory<byte> payload, CancellationToken ct = default)
        {
            var header = new ProtocolHeader
            {
                RouteId = requestHeader.RouteId,
                MessageId = requestHeader.MessageId,
                CategoryId = requestHeader.CategoryId,
                RequestResponse = RequestResponseTypeEnum.Response,
                SequenceNumber = requestHeader.SequenceNumber
            }.ToByteArray();

            var frame = MhcpWire.Build(header, payload.IsEmpty ? Array.Empty<byte>() : payload.ToArray());
            return stream.WriteAsync(frame, ct).AsTask();
        }

        private ReadOnlyMemory<byte> BuildPayload(int messageId)
        {
            _logger?.LogDebug("Sending request messageId={MessageId}", messageId);

            switch (messageId)
            {
                case MhcpConstants.REQ_HEART_FREQ_SET:
                    return new HeartbeatCycleRequest
                    {
                        HeartbeatExpirationPeriodInSeconds = (uint)_defaultHeartbeatSeconds
                    }.ToByteArray();

                case MhcpConstants.REQ_DEVICE_INFO:
                case MhcpConstants.REQ_STATION_INFO:
                case MhcpConstants.REQ_PATIENT_INFO:
                case MhcpConstants.REQ_PERIODIC_INFUSION_INTERVAL:
                    return new PeriodicInfusionIntervalRequest
                    { 
                        IntervalSeconds = 3
                    }.ToByteArray();

               

                default:
                    return ReadOnlyMemory<byte>.Empty;
            }
        }
    }
}
