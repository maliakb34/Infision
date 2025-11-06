using System.Collections.Generic;

namespace Infision.MHCP.Entities.Request
{
    public sealed class HeartbeatCycleRequest
    {
        public uint HeartbeatExpirationPeriodInSeconds { get; set; }

        public byte[] ToByteArray()
        {
            var b = new List<byte>(8);
            // field 1 (varint)
            WriteVarint(b, 1u << 3);
            WriteVarint(b, HeartbeatExpirationPeriodInSeconds);
            return b.ToArray();
        }

        private static void WriteVarint(List<byte> buf, uint v)
        {
            while (v >= 0x80)
            {
                buf.Add((byte)(v & 0x7F | 0x80));
                v >>= 7;
            }
            buf.Add((byte)v);
        }
    }
}

