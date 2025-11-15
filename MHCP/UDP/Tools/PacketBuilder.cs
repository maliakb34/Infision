using System;

namespace Infision.MHCP.UDP.Tools
{
    public static class PacketBuilder
    {
        private const byte HeaderFlag = 0xFA;
        private const int HeaderLength = 11;

        public static byte[] BuildPatientInfoRequest()
        {
            return BuildCommandPacket(0x0306, 0xFF, ReadOnlySpan<byte>.Empty);
        }

        public static byte[] BuildCommandPacket(int commandCode, int transmitId, ReadOnlySpan<byte> payload)
        {
            var packet = new byte[HeaderLength + payload.Length];
            var span = packet.AsSpan();
            span[0] = HeaderFlag;
            span[1] = (byte)(commandCode & 0xFF);
            span[2] = (byte)((commandCode >> 8) & 0xFF);
            span[3] = (byte)(payload.Length & 0xFF);
            span[4] = (byte)((payload.Length >> 8) & 0xFF);
            span[5] = (byte)transmitId;
            if (!payload.IsEmpty)
            {
                payload.CopyTo(span.Slice(HeaderLength));
            }

            byte checksum = 0;
            for (int i = 0; i < span.Length; i++)
            {
                if (i == 10)
                    continue;

                checksum = (byte)(checksum + span[i]);
            }

            span[10] = checksum;
            return packet;
        }
    }
}
