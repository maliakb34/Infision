using System;
using System.Threading;
using System.Threading.Tasks;
using Infision.MHCP;
using Infision.MHCP.Proto;
using Microsoft.Extensions.Logging;

namespace Infision.MHCP.Requests
{
    public sealed class ReqDeviceInfoHandler : IMhcpMessageHandler
    {
        public int MessageId => MhcpConstants.REQ_DEVICE_INFO;

        public Task HandleAsync(ProtocolHeader header, ReadOnlyMemory<byte> payload, MhcpMessageContext context, CancellationToken ct = default)
        {
            context.Logger?.LogInformation("REQ_DEVICE_INFO response received from {Device}. PayloadLength={Length}",
                context.Device.Address,
                payload.Length);
            // TODO: Parse PbDeviceInfo.DeviceInfoResponse when model is available.
            return Task.CompletedTask;
        }
    }
}

