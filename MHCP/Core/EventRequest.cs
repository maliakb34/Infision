using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Infision;
using Infision.MHCP.Entities;
using Infision.MHCP.Proto;
using Infision.MHCP.Types;


namespace Infision.MHCP.Core
{
    public sealed class EventRequest
    {
        private readonly int _defaultHeartbeatSeconds;

        public EventRequest(int defaultHeartbeatSeconds = 5)
        {
            _defaultHeartbeatSeconds = defaultHeartbeatSeconds;
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

        private ReadOnlyMemory<byte> BuildPayload(int messageId)
        {
            switch (messageId)
            {
                case MhcpConstants.REQ_HEART_FREQ_SET:
                    return new HeartbeatCycleRequest
                    {
                        HeartbeatExpirationPeriodInSeconds = (uint)_defaultHeartbeatSeconds
                    }.ToByteArray();

                default:
                    return ReadOnlyMemory<byte>.Empty;
            }
        }
    }
}

