using System.Collections.Generic;

namespace Infision.MHCP.Entities.Request
{
    /// <summary>
    /// Represents PbInfusionInterval.PeriodicInfusionIntervalRequest.
    /// </summary>
    public sealed class PeriodicInfusionIntervalRequest
    {
        /// <summary>
        /// Desired event interval in seconds (field #1).
        /// </summary>
        public int IntervalSeconds { get; set; }

        /// <summary>
        public byte[] ToByteArray()
        {
            var bytes = new List<byte>(8);
            WriteField(bytes, 1, IntervalSeconds);
            return bytes.ToArray();
        }

        private static void WriteField(List<byte> buffer, int fieldNumber, int value)
        {
            WriteVarint(buffer, (uint)(fieldNumber << 3)); // wire type 0 (varint)
            WriteVarint(buffer, unchecked((uint)value));
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

