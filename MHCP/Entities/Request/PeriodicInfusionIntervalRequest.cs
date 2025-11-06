using System.Collections.Generic;

namespace Infision.MHCP.Entities.Request
{
    /// <summary>
    /// Represents PbInfusionInterval.PeriodicInfusionIntervalRequest
    /// (single varint field: intervalSeconds).
    /// </summary>
    public sealed class PeriodicInfusionIntervalRequest
    {
        /// <summary>
        /// Desired event interval in seconds.
        /// </summary>
        public uint IntervalSeconds { get; set; }

        public byte[] ToByteArray()
        {
            var bytes = new List<byte>(8);
            WriteVarint(bytes, 1u << 3); // field=1, wire=0
            WriteVarint(bytes, IntervalSeconds);
            return bytes.ToArray();
        }

        private static void WriteVarint(List<byte> buffer, uint value)
        {
            while (value >= 0x80)
            {
                buffer.Add((byte)(value | 0x80));
                value >>= 7;
            }
            buffer.Add((byte)value);
        }
    }
}

