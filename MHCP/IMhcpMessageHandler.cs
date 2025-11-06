using Infision.MHCP.Proto;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP
{
    public interface IMhcpMessageHandler
    {
        int MessageId { get; }

        Task HandleAsync(ProtocolHeader header, ReadOnlyMemory<byte> payload, MhcpMessageContext context, CancellationToken ct = default);
    }
}

