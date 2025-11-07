using Infision.MHCP.Proto;
using System.Text;

namespace Infision.MHCP.Entities.Response
{
    public sealed class DeviceIdentifier
    {
        public string ModelNumber { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public DeviceTypeEnum DeviceType { get; set; }
        public string ChipId { get; set; } = string.Empty;

        public static DeviceIdentifier Parse(ReadOnlySpan<byte> data)
        {
            var id = new DeviceIdentifier();
            var reader = new ProtobufReader(data);
            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 2:
                        id.ModelNumber = Encoding.UTF8.GetString(reader.ReadLengthDelimited());
                        break;
                    case 2 when wireType == 2:
                        id.SerialNumber = Encoding.UTF8.GetString(reader.ReadLengthDelimited());
                        break;
                    case 3 when wireType == 0:
                        id.DeviceType = (DeviceTypeEnum)reader.ReadVarint();
                        break;
                    case 4 when wireType == 2:
                        id.ChipId = Encoding.UTF8.GetString(reader.ReadLengthDelimited());
                        break;
                    default:
                        SkipUnknown(ref reader, wireType);
                        break;
                }
            }
            return id;
        }

        private static void SkipUnknown(ref ProtobufReader reader, int wireType)
        {
            switch (wireType)
            {
                case 0:
                    reader.ReadVarint();
                    break;
                case 1:
                    reader.ReadFixed64();
                    break;
                case 2:
                    reader.ReadLengthDelimited();
                    break;
                case 5:
                    reader.ReadFixed32();
                    break;
            }
        }
    }

    public enum DeviceTypeEnum
    {
        None = 0,
        Station = 1,
        Syringe = 2,
        Infusion = 3,
        Nutrition = 4,
        MobileStation = 5
    }
}

