using Infision.MHCP.UDP.Model;
using System;
using System.Text;

namespace Infision.MHCP.UDP
{
    public sealed class PatientStationAnalyzer
    {
        public PatientStationInfo Parse(byte[] data)
        {
            if (data is null || data.Length < 20)
                throw new ArgumentException("Invalid payload length for patient station info", nameof(data));

            var cursor = 11;

            string ReadString(int length, Encoding encoding)
            {
                var value = encoding.GetString(data, cursor, length).Trim();
                cursor += length;
                return value;
            }

            byte ReadByte() => data[cursor++];

            float ReadFloat()
            {
                var value = BitConverter.ToSingle(data, cursor);
                cursor += 4;
                return value;
            }

            return new PatientStationInfo
            {
                HospitalId = ReadString(19, Encoding.ASCII),
                Name = ReadString(19, Encoding.ASCII),
                Sex = ReadByte(),
                Age = ReadByte(),
                Height = ReadFloat(),
                Weight = ReadFloat(),
                PatientType = ReadByte(),
                Department = ReadString(19, Encoding.ASCII),
                Room = ReadString(11, Encoding.ASCII),
                Bed = ReadString(7, Encoding.ASCII),
                Advice = ReadString(129, Encoding.ASCII)
            };
        }
    }
}
