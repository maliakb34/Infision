using System;
using System.Text;

namespace Infision.MHCP.UDP.Model
{
    public sealed class PatientStationInfo
    {
        private const int PayloadLength = 215;
        private const int HospitalOffset = 0;
        private const int HospitalLength = 19;
        private const int NameOffset = HospitalOffset + HospitalLength;
        private const int NameLength = 19;
        private const int AgeFieldStart = NameOffset + NameLength;
        private const int SexByteOffset = AgeFieldStart;           // matches MP60 SEX_POS
        private const int AgeByteOffset = AgeFieldStart + 1;       // matches MP60 AGE_POS
        private const int HeightOffset = AgeFieldStart + 2;
        private const int WeightOffset = HeightOffset + 4;
        private const int PatientTypeOffset = WeightOffset + 4;
        private const int DepartmentOffset = PatientTypeOffset + 1;
        private const int DepartmentLength = 19;
        private const int RoomOffset = DepartmentOffset + DepartmentLength;
        private const int RoomLength = 11;
        private const int BedOffset = RoomOffset + RoomLength;
        private const int BedLength = 7;
        private const int AdviceOffset = BedOffset + BedLength;
        private const int AdviceLength = 129;
        private static readonly Encoding Utf8Encoding = Encoding.UTF8;

        public string HospitalId { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public byte Age { get; init; }
        public byte Sex { get; init; }
        public float Height { get; init; }
        public float Weight { get; init; }
        public byte PatientType { get; init; }
        public string Department { get; init; } = string.Empty;
        public string Room { get; init; } = string.Empty;
        public string Bed { get; init; } = string.Empty;
        public string Advice { get; init; } = string.Empty;

        public byte[] ToCommandPayload()
        {
            var buffer = new byte[PayloadLength];

            WriteAscii(buffer, HospitalOffset, HospitalLength, HospitalId);
            WriteAscii(buffer, NameOffset, NameLength, Name);

            buffer[SexByteOffset] = Sex;
            buffer[AgeByteOffset] = Age;

            WriteFloat(buffer, HeightOffset, Height);
            WriteFloat(buffer, WeightOffset, Weight);

            buffer[PatientTypeOffset] = PatientType;

            WriteAscii(buffer, DepartmentOffset, DepartmentLength, Department);
            WriteAscii(buffer, RoomOffset, RoomLength, Room);
            WriteAscii(buffer, BedOffset, BedLength, Bed);
            WriteAscii(buffer, AdviceOffset, AdviceLength, Advice);

            return buffer;
        }

        private static void WriteAscii(byte[] buffer, int offset, int length, string value)
        {
            Array.Clear(buffer, offset, length);
            var text = value ?? string.Empty;
            var bytes = Utf8Encoding.GetBytes(text);
            Buffer.BlockCopy(bytes, 0, buffer, offset, Math.Min(bytes.Length, length));
        }

        private static void WriteFloat(byte[] buffer, int offset, float value)
        {
            var bytes = BitConverter.GetBytes(value);
            Buffer.BlockCopy(bytes, 0, buffer, offset, bytes.Length);
        }
    }
}
