using System;

namespace Infision.MHCP.Proto
{
    // Minimal protobuf wire reader (varint, length-delimited, 32/64-bit fixed)
    internal ref struct ProtobufReader
    {
        private ReadOnlySpan<byte> _span;
        public int Position { get; private set; }
        public int Length => _span.Length;

        public ProtobufReader(ReadOnlySpan<byte> span)
        {
            _span = span;
            Position = 0;
        }

        public bool EOF => Position >= _span.Length;

        public uint ReadVarint()
        {
            uint result = 0; int shift = 0;
            while (true)
            {
                if (Position >= _span.Length) throw new IndexOutOfRangeException();
                byte b = _span[Position++];
                result |= (uint)(b & 0x7F) << shift;
                if ((b & 0x80) == 0) break;
                shift += 7;
                if (shift > 35) throw new FormatException("Varint too long");
            }
            return result;
        }

        public ulong ReadVarint64()
        {
            ulong result = 0; int shift = 0;
            while (true)
            {
                if (Position >= _span.Length) throw new IndexOutOfRangeException();
                byte b = _span[Position++];
                result |= (ulong)(b & 0x7F) << shift;
                if ((b & 0x80) == 0) break;
                shift += 7;
                if (shift > 70) throw new FormatException("Varint64 too long");
            }
            return result;
        }

        public ReadOnlySpan<byte> ReadLengthDelimited()
        {
            uint len = ReadVarint();
            if (Position + (int)len > _span.Length) throw new IndexOutOfRangeException();
            var s = _span.Slice(Position, (int)len);
            Position += (int)len;
            return s;
        }

        public uint ReadFixed32()
        {
            if (Position + 4 > _span.Length) throw new IndexOutOfRangeException();
            var s = _span.Slice(Position, 4);
            Position += 4;
            return (uint)(s[0] | s[1] << 8 | s[2] << 16 | s[3] << 24);
        }

        public ulong ReadFixed64()
        {
            if (Position + 8 > _span.Length) throw new IndexOutOfRangeException();
            var s = _span.Slice(Position, 8);
            Position += 8;
            return s[0] | (ulong)s[1] << 8 | (ulong)s[2] << 16 | (ulong)s[3] << 24
                 | (ulong)s[4] << 32 | (ulong)s[5] << 40 | (ulong)s[6] << 48 | (ulong)s[7] << 56;
        }

        public (uint field, int wireType) ReadKey()
        {
            uint key = ReadVarint();
            return (key >> 3, (int)(key & 0x7));
        }
    }
}

