using System.Collections.Generic;

namespace Infision.PayloadBuilder.Builders
{
    public enum Endianness
    {
        Little,
        Big
    }

    public enum FieldType
    {
        Int8,
        UInt8,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64,
        Float32,
        Float64,
        Bool,
        Ascii,
        Utf8,
        Bytes,
        UnixSeconds
    }

    public class FieldSpec
    {
        public string Name { get; set; } = string.Empty;
        public FieldType Type { get; set; }
        public int Length { get; set; }
        public Endianness Endian { get; set; } = Endianness.Little;
        public bool Padded { get; set; }
        public byte PadByte { get; set; } = 0x00;
        public bool IsLengthOfMessage { get; set; }
        public bool IsCrc16 { get; set; }
    }

    public class MessageSchema
    {
        public List<FieldSpec> Fields { get; } = new List<FieldSpec>();
        public int CrcStartOffset { get; set; } = 0;
        public ushort CrcPolynomial { get; set; } = 0x1021;
        public ushort CrcInitialValue { get; set; } = 0xFFFF;
        public ushort CrcXorOut { get; set; } = 0x0000;
        public bool CrcRefIn { get; set; } = false;
        public bool CrcRefOut { get; set; } = false;
        public Endianness CrcEndian { get; set; } = Endianness.Big;
    }
}
