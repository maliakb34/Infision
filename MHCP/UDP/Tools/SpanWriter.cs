using System;
using System.Text;

namespace Infision.MHCP.UDP.Tools
{
    public sealed class SpanWriter
    {
        private readonly byte[] _buffer;
        private int _position;

        public SpanWriter(byte[] buffer)
        {
            _buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            _position = 0;
        }

        public void WriteFixedString(string value, int length, Encoding? encoding = null)
        {
            encoding ??= Encoding.ASCII;
            var bytes = encoding.GetBytes(value ?? string.Empty);
            var count = Math.Min(bytes.Length, length);
            Array.Copy(bytes, 0, _buffer, _position, count);
            if (count < length)
            {
                Array.Clear(_buffer, _position + count, length - count);
            }

            _position += length;
        }

        public void WriteByte(byte value)
        {
            _buffer[_position++] = value;
        }

        public void WriteFloat(float value)
        {
            var bytes = BitConverter.GetBytes(value);
            Array.Copy(bytes, 0, _buffer, _position, bytes.Length);
            _position += bytes.Length;
        }
    }
}
