namespace Infision.MHCP
{
    public sealed class MhcpFrame
    {
        public ProtocolHeader Header { get; set; } = new ProtocolHeader();
        public byte[] Payload { get; set; } = System.Array.Empty<byte>();
    }
}

