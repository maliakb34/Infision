using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP
{
    public static class MhcpClientHelpers
    {
        // Reads frames until the 257 heartbeat RESPONSE arrives.
        // Auto-replies to protocol heart (messageId=1) requests with an empty RESPONSE.
        public static async Task WaitForHeartbeatResponseAsync(NetworkStream stream, TimeSpan timeout, CancellationToken ct = default)
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(timeout);

            while (true)
            {
                var (hBytes, pBytes) = await MhcpWire.ReadFrameAsync(stream, cts.Token);
                var hdr = ProtocolHeader.Parse(hBytes);

                // If it's a protocol heart request (messageId=1, categoryId probably 1), reply
                if (hdr.MessageId == 1 && hdr.RequestResponse == RequestResponseTypeEnum.Request)
                {
                    var respHeader = new ProtocolHeader
                    {
                        RouteId = hdr.RouteId,
                        MessageId = hdr.MessageId,
                        CategoryId = hdr.CategoryId,
                        RequestResponse = RequestResponseTypeEnum.Response,
                        SequenceNumber = hdr.SequenceNumber
                    }.ToByteArray();
                    var respFrame = MhcpWire.Build(respHeader, Array.Empty<byte>());
                    await stream.WriteAsync(respFrame, cts.Token);
                    continue;
                }

                // If it's the heartbeat (257) RESPONSE we expect, return
                if (hdr.MessageId == 257 && hdr.RequestResponse == RequestResponseTypeEnum.Response)
                {
                    return;
                }

                // Otherwise, ignore and continue draining until timeout
            }
        }

        // Reads frames until the 258 DeviceInfo RESPONSE arrives; ignores other frames.
        public static async Task<(ProtocolHeader Header, byte[] Payload)> WaitForDeviceInfoResponseAsync(NetworkStream stream, TimeSpan timeout, CancellationToken ct = default)
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(timeout);

            while (true)
            {
                var (hBytes, pBytes) = await MhcpWire.ReadFrameAsync(stream, cts.Token);
                var hdr = ProtocolHeader.Parse(hBytes);
                Console.WriteLine($"DBG hdr: msgId={hdr.MessageId} rr={hdr.RequestResponse} cat={hdr.CategoryId} seq={hdr.SequenceNumber}");
                // Auto-reply to protocol heart REQUESTs if they appear while waiting
                if (hdr.MessageId == 1 && hdr.RequestResponse == RequestResponseTypeEnum.Request)
                {
                    var respHeader = new ProtocolHeader
                    {
                        RouteId = hdr.RouteId,
                        MessageId = hdr.MessageId,
                        CategoryId = hdr.CategoryId,
                        RequestResponse = RequestResponseTypeEnum.Response,
                        SequenceNumber = hdr.SequenceNumber
                    }.ToByteArray();
                    var respFrame = MhcpWire.Build(respHeader, Array.Empty<byte>());
                    await stream.WriteAsync(respFrame, cts.Token);
                    continue;
                }

                if (hdr.MessageId == 258 && hdr.RequestResponse == RequestResponseTypeEnum.Response)
                {
                    return (hdr, pBytes);
                }
                // else ignore and continue
            }
        }

        // Reads frames until the 4096 StationInfo RESPONSE arrives; ignores other frames.
        public static async Task<(ProtocolHeader Header, byte[] Payload)> WaitForStationInfoResponseAsync(NetworkStream stream, TimeSpan timeout, CancellationToken ct = default)
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(timeout);

            while (true)
            {
                var (hBytes, pBytes) = await MhcpWire.ReadFrameAsync(stream, cts.Token);
                var hdr = ProtocolHeader.Parse(hBytes);

                // Auto-reply to protocol heart REQUESTs if they appear while waiting
                if (hdr.MessageId == 1 && hdr.RequestResponse == RequestResponseTypeEnum.Request)
                {
                    var respHeader = new ProtocolHeader
                    {
                        RouteId = hdr.RouteId,
                        MessageId = hdr.MessageId,
                        CategoryId = hdr.CategoryId,
                        RequestResponse = RequestResponseTypeEnum.Response,
                        SequenceNumber = hdr.SequenceNumber
                    }.ToByteArray();
                    var respFrame = MhcpWire.Build(respHeader, Array.Empty<byte>());
                    await stream.WriteAsync(respFrame, cts.Token);
                    continue;
                }

                if (hdr.MessageId == 4096 && hdr.RequestResponse == RequestResponseTypeEnum.Response)
                {
                    return (hdr, pBytes);
                }
                // else ignore and continue
            }
        }
    }
}
