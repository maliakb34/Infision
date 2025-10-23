using System;
using System.Buffers;
using System.IO;
using System.Text;

namespace Infision.PayloadBuilder.Util
{
    // Minimal protobuf writer supporting: varint, fixed32, fixed64, length-delimited (string/bytes)
    public sealed class ProtoWriter : IDisposable
    {
        private readonly MemoryStream _ms = new MemoryStream();

        public byte[] ToArray() => _ms.ToArray();

        public void Dispose() => _ms.Dispose();

        public void WriteFieldVarint(int fieldNumber, ulong value)
        {
            WriteKey(fieldNumber, 0);
            WriteVarint(value);
        }

        public void WriteFieldFixed32(int fieldNumber, uint value)
        {
            WriteKey(fieldNumber, 5);
            Span<byte> b = stackalloc byte[4];
            b[0] = (byte)(value & 0xFF);
            b[1] = (byte)((value >> 8) & 0xFF);
            b[2] = (byte)((value >> 16) & 0xFF);
            b[3] = (byte)((value >> 24) & 0xFF);
            _ms.Write(b);
        }

        public void WriteFieldFixed64(int fieldNumber, ulong value)
        {
            WriteKey(fieldNumber, 1);
            Span<byte> b = stackalloc byte[8];
            b[0] = (byte)(value & 0xFF);
            b[1] = (byte)((value >> 8) & 0xFF);
            b[2] = (byte)((value >> 16) & 0xFF);
            b[3] = (byte)((value >> 24) & 0xFF);
            b[4] = (byte)((value >> 32) & 0xFF);
            b[5] = (byte)((value >> 40) & 0xFF);
            b[6] = (byte)((value >> 48) & 0xFF);
            b[7] = (byte)((value >> 56) & 0xFF);
            _ms.Write(b);
        }

        public void WriteFieldString(int fieldNumber, string value)
        {
            WriteKey(fieldNumber, 2);
            var bytes = Encoding.UTF8.GetBytes(value ?? string.Empty);
            WriteVarint((ulong)bytes.Length);
            _ms.Write(bytes, 0, bytes.Length);
        }

        public void WriteFieldBytes(int fieldNumber, ReadOnlySpan<byte> bytes)
        {
            WriteKey(fieldNumber, 2);
            WriteVarint((ulong)bytes.Length);
            _ms.Write(bytes);
        }

        public void WriteFieldFloat32(int fieldNumber, float f)
        {
            var u = BitConverter.SingleToUInt32Bits(f);
            WriteFieldFixed32(fieldNumber, u);
        }

        public void WriteFieldDouble64(int fieldNumber, double d)
        {
            var u = BitConverter.DoubleToUInt64Bits(d);
            WriteFieldFixed64(fieldNumber, u);
        }

        private void WriteKey(int fieldNumber, int wireType)
        {
            var key = ((uint)fieldNumber << 3) | (uint)wireType;
            WriteVarint(key);
        }

        private void WriteVarint(ulong value)
        {
            while (value >= 0x80)
            {
                _ms.WriteByte((byte)((value & 0x7F) | 0x80));
                value >>= 7;
            }
            _ms.WriteByte((byte)value);
        }
    }
}
