using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

    namespace Infision
{ 
public static class MhcpPacketBuilder
{
    // ip20 MHCP constants (from code analysis)
    private static readonly byte[] SYNC = new byte[] { 0xFA, 0x05 };
    private const ushort CategoryIdIp20 = 2; // ip20
    private const byte RequestResponse_Request = 0;

    // Protobuf field numbers (adjust here if device schema differs)
    private static class ProtocolHeaderFields
    {
        public const int RouteId = 1;         // uint32
        public const int MessageId = 2;       // uint32
        public const int CategoryId = 3;      // uint32
        public const int RequestResponse = 4; // enum (varint)
        public const int SequenceNumber = 5;  // uint32
    }

    private static class PatientInfoFields
    {
        public const int Id = 1;               // string
        public const int DepartmentName = 2;   // string
        public const int BedNo = 3;            // string
        public const int Pid = 4;              // string
        public const int VisitId = 5;          // string
        public const int LastName = 6;         // string
        public const int FirstName = 7;        // string
        public const int Gender = 8;           // int32 (enum)
        public const int Age = 9;              // int32
        public const int AgeUnit = 10;         // int32 (enum)
        public const int BloodType = 11;       // int32 (enum)
        public const int Physician = 12;       // string
        public const int Diagnosis = 13;       // string
        public const int Height = 14;          // float
        public const int Weight = 15;          // float
        public const int AdmitDate = 16;       // int64 (epoch seconds)
    }

    public sealed class PatientInfo
    {
        public string Id { get; set; } = "";
        public string DepartmentName { get; set; } = "";
        public string BedNo { get; set; } = "";
        public string Pid { get; set; } = "";
        public string VisitId { get; set; } = "";
        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public int Gender { get; set; }         // 1:FEMALE, 2:MALE gibi
        public int Age { get; set; }
        public int AgeUnit { get; set; }        // ör. 1:DAY, 2:YEAR
        public int BloodType { get; set; }      // ör. 1:A,2:O,...
        public string Physician { get; set; } = "";
        public string Diagnosis { get; set; } = "";
        public float? Height { get; set; }      // cm
        public float? Weight { get; set; }      // kg
        public long? AdmitDate { get; set; }    // epoch seconds
    }

    public static byte[] BuildPatientPacket(int messageId, int sequenceNumber, PatientInfo p)
    {
        // 1) Build protobuf header bytes
        byte[] header = BuildProtocolHeader(routeId: 0, messageId: messageId, categoryId: CategoryIdIp20,
                                            requestResponse: RequestResponse_Request, sequenceNumber: sequenceNumber);

        // 2) Build protobuf patient payload bytes
        byte[] payload = BuildPatientInfoPayload(p);

        // 3) Compute lengths (LE) and CRC16 over [totalLen|headerLen|header|payload]
        ushort headerLen = (ushort)header.Length;
        ushort totalLen = (ushort)(8 + header.Length + payload.Length); // SYNC(2)+CRC(2)+Total(2)+HeaderLen(2)=8

        byte[] totalLenLE = ToUInt16LE(totalLen);
        byte[] headerLenLE = ToUInt16LE(headerLen);

        // CRC input: totalLenLE + headerLenLE + header + payload
        byte[] crcData = Concat(totalLenLE, headerLenLE, header, payload);
        ushort crc = Crc16Ccitt(crcData);

        // 4) Frame: SYNC | CRC(LE) | totalLen(LE) | headerLen(LE) | header | payload
        byte[] frame = Concat(SYNC, ToUInt16LE(crc), crcData);
        return frame;
    }

    // Helpers

    private static byte[] BuildProtocolHeader(uint routeId, int messageId, ushort categoryId, byte requestResponse, int sequenceNumber)
    {
        using (var ms = new MemoryStream())
        using (var w = new ProtoWriter(ms))
        {
            w.WriteVarint(ProtocolHeaderFields.RouteId, routeId);
            w.WriteVarint(ProtocolHeaderFields.MessageId, (uint)messageId);
            w.WriteVarint(ProtocolHeaderFields.CategoryId, categoryId);
            w.WriteVarint(ProtocolHeaderFields.RequestResponse, requestResponse);
            w.WriteVarint(ProtocolHeaderFields.SequenceNumber, (uint)sequenceNumber);
            return ms.ToArray();
        }
    }

    private static byte[] BuildPatientInfoPayload(PatientInfo p)
    {
        using (var ms = new MemoryStream())
        using (var w = new ProtoWriter(ms))
        {
            // Strings
            if (!string.IsNullOrEmpty(p.Id)) w.WriteString(PatientInfoFields.Id, p.Id);
            if (!string.IsNullOrEmpty(p.DepartmentName)) w.WriteString(PatientInfoFields.DepartmentName, p.DepartmentName);
            if (!string.IsNullOrEmpty(p.BedNo)) w.WriteString(PatientInfoFields.BedNo, p.BedNo);
            if (!string.IsNullOrEmpty(p.Pid)) w.WriteString(PatientInfoFields.Pid, p.Pid);
            if (!string.IsNullOrEmpty(p.VisitId)) w.WriteString(PatientInfoFields.VisitId, p.VisitId);
            if (!string.IsNullOrEmpty(p.LastName)) w.WriteString(PatientInfoFields.LastName, p.LastName);
            if (!string.IsNullOrEmpty(p.FirstName)) w.WriteString(PatientInfoFields.FirstName, p.FirstName);
            if (!string.IsNullOrEmpty(p.Physician)) w.WriteString(PatientInfoFields.Physician, p.Physician);
            if (!string.IsNullOrEmpty(p.Diagnosis)) w.WriteString(PatientInfoFields.Diagnosis, p.Diagnosis);

            // Enums / ints
            if (p.Gender != 0) w.WriteVarint(PatientInfoFields.Gender, (uint)p.Gender);
            if (p.Age != 0) w.WriteVarint(PatientInfoFields.Age, (uint)p.Age);
            if (p.AgeUnit != 0) w.WriteVarint(PatientInfoFields.AgeUnit, (uint)p.AgeUnit);
            if (p.BloodType != 0) w.WriteVarint(PatientInfoFields.BloodType, (uint)p.BloodType);

            // Floats
            if (p.Height.HasValue) w.WriteFloat(PatientInfoFields.Height, p.Height.Value);
            if (p.Weight.HasValue) w.WriteFloat(PatientInfoFields.Weight, p.Weight.Value);

            // Timestamp
            if (p.AdmitDate.HasValue) w.WriteVarint64(PatientInfoFields.AdmitDate, (ulong)p.AdmitDate.Value);

            return ms.ToArray();
        }
    }

    private static byte[] ToUInt16LE(ushort v) => new[] { (byte)(v & 0xFF), (byte)((v >> 8) & 0xFF) };

    private static byte[] Concat(params byte[][] parts)
    {
        int len = 0;
        foreach (var p in parts) len += p.Length;
        var buf = new byte[len];
        int pos = 0;
        foreach (var p in parts)
        {
            Buffer.BlockCopy(p, 0, buf, pos, p.Length);
            pos += p.Length;
        }
        return buf;
    }

    // CRC16-CCITT (poly 0x1021, init 0xFFFF, reflected table as in ip20 code)
    private static readonly ushort[] Crc16Poly1021Reflect =
    {
    0x0000,0x1189,0x2312,0x329B,0x4624,0x57AD,0x6536,0x74BF,0x8C48,0x9DC1,0xAF5A,0xBED3,0xCA6C,0xDBE5,0xE97E,0xF8F7,
    0x1081,0x0108,0x3393,0x221A,0x56A5,0x472C,0x75B7,0x643E,0x9CC9,0x8D40,0xBFDB,0xAE52,0xDAED,0xCB64,0xF9FF,0xE876,
    0x2102,0x308B,0x0210,0x1399,0x6726,0x76AF,0x4434,0x55BD,0xAD4A,0xBCC3,0x8E58,0x9FD1,0xEB6E,0xFAE7,0xC87C,0xD9F5,
    0x3183,0x200A,0x1291,0x0318,0x77A7,0x662E,0x54B5,0x453C,0xBDCB,0xAC42,0x9ED9,0x8F50,0xFBED,0xEA64,0xD8FF,0xC976,
    0x4204,0x538D,0x6116,0x709F,0x0420,0x15A9,0x2732,0x36BB,0xCE4C,0xDFC5,0xED5E,0xFCD7,0x8868,0x99E1,0xAB7A,0xBAF3,
    0x5285,0x430C,0x7197,0x601E,0x14A1,0x0528,0x37B3,0x263A,0xDECD,0xCF44,0xFDDF,0xEC56,0x98E9,0x8960,0xBBFB,0xAA72,
    0x6306,0x728F,0x4014,0x519D,0x2522,0x34AB,0x0630,0x17B9,0xEF4E,0xFEC7,0xCC5C,0xDDD5,0xA96A,0xB8E3,0x8A78,0x9BF1,
    0x7387,0x620E,0x5095,0x411C,0x35A3,0x242A,0x16B1,0x0738,0xFFCF,0xEE46,0xDCDD,0xCD54,0xB9EB,0xA862,0x9AF9,0x8B70,
    0x8408,0x9581,0xA71A,0xB693,0xC22C,0xD3A5,0xE13E,0xF0B7,0x0840,0x19C9,0x2B52,0x3ADB,0x4E64,0x5FED,0x6D76,0x7CFF,
    0x9489,0x8500,0xB79B,0xA612,0xD2AD,0xC324,0xF1BF,0xE036,0x18C1,0x0948,0x3BD3,0x2A5A,0x5EE5,0x4F6C,0x7DF7,0x6C7E,
    0xA50A,0xB483,0x8618,0x9791,0xE32E,0xF2A7,0xC03C,0xD1B5,0x2942,0x38CB,0x0A50,0x1BD9,0x6F66,0x7EEF,0x4C74,0x5DFD,
    0xB58B,0xA402,0x9699,0x8710,0xF3AF,0xE226,0xD0BD,0xC134,0x39C3,0x284A,0x1AD1,0x0B58,0x7FE7,0x6E6E,0x5CF5,0x4D7C,
    0xC60C,0xD785,0xE51E,0xF497,0x8028,0x91A1,0xA33A,0xB2B3,0x4A44,0x5BCD,0x6956,0x78DF,0x0C60,0x1DE9,0x2F72,0x3EFB,
    0xD68D,0xC704,0xF59F,0xE416,0x90A9,0x8120,0xB3BB,0xA232,0x5AC5,0x4B4C,0x79D7,0x685E,0x1CE1,0x0D68,0x3FF3,0x2E7A,
    0xE70E,0xF687,0xC41C,0xD595,0xA12A,0xB0A3,0x8238,0x93B1,0x6B46,0x7ACF,0x4854,0x59DD,0x2D62,0x3CEB,0x0E70,0x1FF9,
    0xF78F,0xE606,0xD49D,0xC514,0xB1AB,0xA022,0x92B9,0x8330,0x7BC7,0x6A4E,0x58D5,0x495C,0x3DE3,0x2C6A,0x1EF1,0x0F78
};

    private static ushort Crc16Ccitt(byte[] data)
    {
        int crc = 0xFFFF;
        for (int i = 0; i < data.Length; i++)
        {
            int index = (crc ^ data[i]) & 0xFF;
            crc = (crc >> 8) ^ Crc16Poly1021Reflect[index];
        }
        return (ushort)(crc & 0xFFFF);
    }

    // Minimal protobuf writer for our fields
    private sealed class ProtoWriter : IDisposable
    {
        private readonly MemoryStream _ms;
        public ProtoWriter(MemoryStream ms) { _ms = ms; }

        public void WriteVarint(int fieldNumber, uint value)
        {
            WriteKey(fieldNumber, 0); // varint
            WriteVarintRaw(value);
        }

        public void WriteVarint64(int fieldNumber, ulong value)
        {
            WriteKey(fieldNumber, 0); // varint
            WriteVarintRaw64(value);
        }

        public void WriteString(int fieldNumber, string value)
        {
            if (value == null) value = "";
            var utf8 = Encoding.UTF8.GetBytes(value);
            WriteKey(fieldNumber, 2); // length-delimited
            WriteVarintRaw((uint)utf8.Length);
            _ms.Write(utf8, 0, utf8.Length);
        }

        public void WriteFloat(int fieldNumber, float value)
        {
            WriteKey(fieldNumber, 5); // 32-bit
            var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian) Array.Reverse(bytes);
            _ms.Write(bytes, 0, 4);
        }

        private void WriteKey(int fieldNumber, int wireType)
        {
            uint key = ((uint)fieldNumber << 3) | (uint)wireType;
            WriteVarintRaw(key);
        }

        private void WriteVarintRaw(uint value)
        {
            while (value >= 0x80)
            {
                _ms.WriteByte((byte)(value | 0x80));
                value >>= 7;
            }
            _ms.WriteByte((byte)value);
        }

        private void WriteVarintRaw64(ulong value)
        {
            while (value >= 0x80)
            {
                _ms.WriteByte((byte)(value | 0x80));
                value >>= 7;
            }
            _ms.WriteByte((byte)value);
        }

        public void Dispose() { /* no-op */ }
    }
}
    }