using System;

namespace Infision.PayloadBuilder.Util
{
    public static class Crc16
    {
        public static ushort ComputeCcitt(ReadOnlySpan<byte> data, ushort poly = 0x1021, ushort init = 0xFFFF, ushort xorOut = 0x0000, bool refIn = false, bool refOut = false)
        {
            ushort crc = init;
            foreach (var b in data)
            {
                var cur = refIn ? Reverse8(b) : b;
                crc ^= (ushort)(cur << 8);
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0) crc = (ushort)((crc << 1) ^ poly);
                    else crc <<= 1;
                }
            }
            if (refOut) crc = Reverse16(crc);
            return (ushort)(crc ^ xorOut);
        }

            static byte Reverse8(byte b)
            {
                b = (byte)(((b & 0xF0) >> 4) | ((b & 0x0F) << 4));
                b = (byte)(((b & 0xCC) >> 2) | ((b & 0x33) << 2));
                b = (byte)(((b & 0xAA) >> 1) | ((b & 0x55) << 1));
                return b;
            }

            static ushort Reverse16(ushort v)
            {
                v = (ushort)(((v & 0xFF00) >> 8) | ((v & 0x00FF) << 8));
                v = (ushort)(((v & 0xF0F0) >> 4) | ((v & 0x0F0F) << 4));
                v = (ushort)(((v & 0xCCCC) >> 2) | ((v & 0x3333) << 2));
                v = (ushort)(((v & 0xAAAA) >> 1) | ((v & 0x5555) << 1));
                return v;
            }
    }
}
