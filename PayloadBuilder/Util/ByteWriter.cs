using System;
using System.IO;
using System.Text;

namespace Infision.PayloadBuilder.Util
{
    public class ByteWriter
    {
        readonly MemoryStream _ms = new MemoryStream();

        public long Position => _ms.Position;
        public byte[] ToArray() => _ms.ToArray();

        public void WriteBool(bool v) => _ms.WriteByte((byte)(v ? 1 : 0));
        public void WriteInt8(sbyte v) => _ms.WriteByte(unchecked((byte)v));
        public void WriteUInt8(byte v) => _ms.WriteByte(v);

        public void WriteInt16(short v, bool littleEndian)
        {
            var bytes = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 2);
        }

        public void WriteUInt16(ushort v, bool littleEndian)
        {
            var bytes = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 2);
        }

        public void WriteInt32(int v, bool littleEndian)
        {
            var bytes = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 4);
        }

        public void WriteUInt32(uint v, bool littleEndian)
        {
            var bytes = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 4);
        }

        public void WriteInt64(long v, bool littleEndian)
        {
            var bytes = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 8);
        }

        public void WriteUInt64(ulong v, bool littleEndian)
        {
            var bytes = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 8);
        }

        public void WriteFloat32(float v, bool littleEndian)
        {
            var bytes = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 4);
        }

        public void WriteFloat64(double v, bool littleEndian)
        {
            var bytes = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 8);
        }

        public void WriteAscii(string s, int length, byte padByte, bool padded)
        {
            var bytes = Encoding.ASCII.GetBytes(s ?? string.Empty);
            WriteBytesFixed(bytes, length, padByte, padded);
        }

        public void WriteUtf8(string s, int length, byte padByte, bool padded)
        {
            var bytes = Encoding.UTF8.GetBytes(s ?? string.Empty);
            WriteBytesFixed(bytes, length, padByte, padded);
        }

        public void WriteBytesFixed(byte[] bytes, int length, byte padByte, bool padded)
        {
            if (length <= 0)
            {
                _ms.Write(bytes, 0, bytes.Length);
                return;
            }
            var toWrite = Math.Min(bytes.Length, length);
            _ms.Write(bytes, 0, toWrite);
            if (padded && toWrite < length)
            {
                var pad = new byte[length - toWrite];
                if (padByte != 0)
                    for (int i = 0; i < pad.Length; i++) pad[i] = padByte;
                _ms.Write(pad, 0, pad.Length);
            }
        }

        public void OverwriteAt(long position, byte[] bytes)
        {
            var cur = _ms.Position;
            _ms.Position = position;
            _ms.Write(bytes, 0, bytes.Length);
            _ms.Position = cur;
        }
    }
}
