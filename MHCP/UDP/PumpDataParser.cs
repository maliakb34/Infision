using Infision.MHCP.UDP.Model;
using System;
using System.Text;

namespace Infision.MHCP.UDP
{
    public sealed class PumpDataParser
    {
        public PumpRealData Parse(byte[] data)
        {
            if (data is null || data.Length < 20)
                throw new ArgumentException("Invalid payload length for pump data", nameof(data));

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

            uint ReadUInt32()
            {
                var value = BitConverter.ToUInt32(data, cursor);
                cursor += 4;
                return value;
            }

            return new PumpRealData
            {
                Serial = ReadString(19, Encoding.ASCII),
                DeviceType = ReadByte(),
                Model = ReadString(19, Encoding.ASCII),
                Workstation = ReadString(19, Encoding.ASCII),
                Department = ReadString(19, Encoding.ASCII),
                Room = ReadString(11, Encoding.ASCII),
                Bed = ReadString(7, Encoding.ASCII),
                State = ReadByte(),
                Drug = ReadString(25, Encoding.UTF8),
                Mode = ReadByte(),
                Vtbi = ReadFloat(),
                Rate = ReadFloat(),
                InfusedTime = ReadUInt32(),
                RemainingTime = ReadUInt32(),
                Infused = ReadFloat(),
                Remaining = ReadFloat(),
                Alarm = ReadUInt32()
            };
        }
    }
}
