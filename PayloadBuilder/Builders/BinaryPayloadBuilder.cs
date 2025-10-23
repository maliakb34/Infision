using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Infision.PayloadBuilder.Util;

namespace Infision.PayloadBuilder.Builders
{
    public class BinaryPayloadBuilder
    {
        readonly MessageSchema _schema;

        public BinaryPayloadBuilder(MessageSchema schema)
        {
            _schema = schema;
        }

        public byte[] Build(IDictionary<string, object> values)
        {
            var w = new ByteWriter();
            var lengthFieldPos = new Dictionary<string, long>();

            foreach (var f in _schema.Fields)
            {
                var endianLittle = f.Endian == Endianness.Little;

                if (f.IsLengthOfMessage)
                {
                    lengthFieldPos[f.Name] = w.Position;
                    WritePlaceholderLength(w, f, endianLittle);
                    continue;
                }

                if (f.IsCrc16)
                {
                    var data = w.ToArray().AsSpan(_schema.CrcStartOffset);
                    var crc = Crc16.ComputeCcitt(data, _schema.CrcPolynomial, _schema.CrcInitialValue, _schema.CrcXorOut, _schema.CrcRefIn, _schema.CrcRefOut);
                    if (f.Length == 1)
                    {
                        var b = (byte)(crc & 0xFF);
                        w.WriteUInt8(b);
                    }
                    else
                    {
                        if (endianLittle) w.WriteUInt16(crc, true); else w.WriteUInt16(crc, false);
                    }
                    continue;
                }

                if (!values.TryGetValue(f.Name, out var v)) v = GetDefaultFor(f);

                switch (f.Type)
                {
                    case FieldType.Bool:
                        w.WriteBool(Convert.ToBoolean(v, CultureInfo.InvariantCulture));
                        break;
                    case FieldType.Int8:
                        w.WriteInt8(Convert.ToSByte(v, CultureInfo.InvariantCulture));
                        break;
                    case FieldType.UInt8:
                        w.WriteUInt8(Convert.ToByte(v, CultureInfo.InvariantCulture));
                        break;
                    case FieldType.Int16:
                        w.WriteInt16(Convert.ToInt16(v, CultureInfo.InvariantCulture), endianLittle);
                        break;
                    case FieldType.UInt16:
                        w.WriteUInt16(Convert.ToUInt16(v, CultureInfo.InvariantCulture), endianLittle);
                        break;
                    case FieldType.Int32:
                        w.WriteInt32(Convert.ToInt32(v, CultureInfo.InvariantCulture), endianLittle);
                        break;
                    case FieldType.UInt32:
                        w.WriteUInt32(Convert.ToUInt32(v, CultureInfo.InvariantCulture), endianLittle);
                        break;
                    case FieldType.Int64:
                        w.WriteInt64(Convert.ToInt64(v, CultureInfo.InvariantCulture), endianLittle);
                        break;
                    case FieldType.UInt64:
                        w.WriteUInt64(Convert.ToUInt64(v, CultureInfo.InvariantCulture), endianLittle);
                        break;
                    case FieldType.Float32:
                        w.WriteFloat32(Convert.ToSingle(v, CultureInfo.InvariantCulture), endianLittle);
                        break;
                    case FieldType.Float64:
                        w.WriteFloat64(Convert.ToDouble(v, CultureInfo.InvariantCulture), endianLittle);
                        break;
                    case FieldType.Ascii:
                        w.WriteAscii(Convert.ToString(v, CultureInfo.InvariantCulture) ?? string.Empty, f.Length, f.PadByte, f.Padded);
                        break;
                    case FieldType.Utf8:
                        w.WriteUtf8(Convert.ToString(v, CultureInfo.InvariantCulture) ?? string.Empty, f.Length, f.PadByte, f.Padded);
                        break;
                    case FieldType.Bytes:
                        var bytes = v as byte[] ?? Array.Empty<byte>();
                        w.WriteBytesFixed(bytes, f.Length, f.PadByte, f.Padded);
                        break;
                    case FieldType.UnixSeconds:
                        var dt = v is DateTime d ? d : DateTimeOffset.Parse(Convert.ToString(v, CultureInfo.InvariantCulture) ?? string.Empty, CultureInfo.InvariantCulture).UtcDateTime;
                        var seconds = (uint)new DateTimeOffset(dt).ToUnixTimeSeconds();
                        w.WriteUInt32(seconds, endianLittle);
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported field type: {f.Type}");
                }
            }

            if (lengthFieldPos.Count > 0)
            {
                var totalLen = checked((uint)w.ToArray().Length);
                foreach (var lf in lengthFieldPos)
                {
                    var spec = _schema.Fields.First(x => x.Name == lf.Key);
                    var endianLittle = spec.Endian == Endianness.Little;
                    var lenBytes = spec.Length switch
                    {
                        <= 1 => new[] { (byte)(totalLen & 0xFF) },
                        2 => GetEndianBytes((ushort)totalLen, endianLittle),
                        4 => GetEndianBytes(totalLen, endianLittle),
                        _ => throw new NotSupportedException("Unsupported length field size")
                    };
                    w.OverwriteAt(lf.Value, lenBytes);
                }
            }

            return w.ToArray();
        }

        static object GetDefaultFor(FieldSpec f)
        {
            return f.Type switch
            {
                FieldType.Bool => false,
                FieldType.Int8 => (sbyte)0,
                FieldType.UInt8 => (byte)0,
                FieldType.Int16 => (short)0,
                FieldType.UInt16 => (ushort)0,
                FieldType.Int32 => 0,
                FieldType.UInt32 => (uint)0,
                FieldType.Int64 => (long)0,
                FieldType.UInt64 => (ulong)0,
                FieldType.Float32 => 0f,
                FieldType.Float64 => 0d,
                FieldType.Ascii => string.Empty,
                FieldType.Utf8 => string.Empty,
                FieldType.Bytes => Array.Empty<byte>(),
                FieldType.UnixSeconds => DateTime.UnixEpoch,
                _ => string.Empty
            };
        }

        static byte[] GetEndianBytes(ushort v, bool little)
        {
            var b = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != little) Array.Reverse(b);
            return b;
        }

        static byte[] GetEndianBytes(uint v, bool little)
        {
            var b = BitConverter.GetBytes(v);
            if (BitConverter.IsLittleEndian != little) Array.Reverse(b);
            return b;
        }

        static void WritePlaceholderLength(ByteWriter w, FieldSpec f, bool little)
        {
            if (f.Length <= 1)
            {
                w.WriteUInt8(0);
            }
            else if (f.Length == 2)
            {
                w.WriteUInt16(0, little);
            }
            else if (f.Length == 4)
            {
                w.WriteUInt32(0, little);
            }
            else
            {
                throw new NotSupportedException("Unsupported length placeholder size");
            }
        }
    }
}
