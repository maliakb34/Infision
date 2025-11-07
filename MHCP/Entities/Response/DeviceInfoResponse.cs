using Infision.MHCP.Proto;
using System;
using System.Text;

namespace Infision.MHCP.Entities.Response
{
    public sealed class DeviceInfoResponse
    {
        public DeviceIdentifier DeviceId { get; set; } = new DeviceIdentifier();
        public string Version { get; set; } = string.Empty;
        public string BootLoaderVersion { get; set; } = string.Empty;
        public string ResourceVersion { get; set; } = string.Empty;
        public string ProtocolVersion { get; set; } = string.Empty;

        public static DeviceInfoResponse Parse(ReadOnlySpan<byte> data)
        {
            var response = new DeviceInfoResponse();
            var reader = new ProtobufReader(data);

            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                switch (field)
                {
                    case 1 when wireType == 2:
                        response.DeviceId = DeviceIdentifier.Parse(reader.ReadLengthDelimited());
                        break;
                    case 2 when wireType == 2:
                        response.Version = Encoding.UTF8.GetString(reader.ReadLengthDelimited());
                        break;
                    case 3 when wireType == 2:
                        response.BootLoaderVersion = Encoding.UTF8.GetString(reader.ReadLengthDelimited());
                        break;
                    case 4 when wireType == 2:
                        response.ResourceVersion = Encoding.UTF8.GetString(reader.ReadLengthDelimited());
                        break;
                    case 5 when wireType == 2:
                        response.ProtocolVersion = Encoding.UTF8.GetString(reader.ReadLengthDelimited());
                        break;
                    default:
                        SkipUnknown(ref reader, wireType);
                        break;
                }
            }

            return response;
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
}

