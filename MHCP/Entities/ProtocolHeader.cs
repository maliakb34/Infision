using System.Collections.Generic;
using System.IO;

namespace Infision.MHCP
{
    public sealed partial class ProtocolHeader
    {
        public uint RouteId { get; set; }
        public uint MessageId { get; set; }
        public uint CategoryId { get; set; }
        public RequestResponseTypeEnum RequestResponse { get; set; }
        public uint SequenceNumber { get; set; }

        public byte[] ToByteArray()
        {
            var b = new List<byte>(32);
            // key = (field<<3) | wireType(0)
            WriteVarint(b, 1u << 3); WriteVarint(b, RouteId);
            WriteVarint(b, 2u << 3); WriteVarint(b, MessageId);
            WriteVarint(b, 3u << 3); WriteVarint(b, CategoryId);
            WriteVarint(b, 4u << 3); WriteVarint(b, (uint)RequestResponse);
            WriteVarint(b, 5u << 3); WriteVarint(b, SequenceNumber);
            return b.ToArray();
        }

        public static ProtocolHeader Parse(byte[] data)
        {
            var h = new ProtocolHeader();
            int i = 0;
            // Collect as map to tolerate different field numbering orders across firmware
            var map = new System.Collections.Generic.Dictionary<uint, uint>();
            while (i < data.Length)
            {
                uint key = ReadVarint(ref i, data); // (field<<3)|wireType
                uint field = key >> 3;
                uint wt = key & 0x7u;
                if (wt != 0) throw new InvalidDataException("Unexpected wire type in header");
                uint val = ReadVarint(ref i, data);
                map[field] = val;
            }

            // Heuristic assignment: prefer standard mapping, fallback if missing
            // Standard: 1=routeId, 2=messageId, 3=categoryId, 4=requestResponse, 5=sequenceNumber
            if (map.TryGetValue(1, out var v1)) h.RouteId = v1;
            if (map.TryGetValue(2, out var v2)) h.MessageId = v2;
            if (map.TryGetValue(3, out var v3)) h.CategoryId = v3;
            if (map.TryGetValue(4, out var v4)) h.RequestResponse = (RequestResponseTypeEnum)v4;
            if (map.TryGetValue(5, out var v5)) h.SequenceNumber = v5;

            // Fallbacks seen in the wild (some devices swap field 1/2)
            if (h.MessageId == 0 && map.TryGetValue(1, out var altMsg)) h.MessageId = altMsg;
            if (h.RouteId == 0 && map.TryGetValue(5, out var altRoute)) h.RouteId = altRoute;
            if (!System.Enum.IsDefined(typeof(RequestResponseTypeEnum), h.RequestResponse))
            {
                // Sometimes requestResponse may appear at field 3 (value 0/1)
                if (map.TryGetValue(3, out var rrVal) && (rrVal == 0u || rrVal == 1u))
                    h.RequestResponse = (RequestResponseTypeEnum)rrVal;
            }

            return h;
        }

        private static void WriteVarint(List<byte> buf, uint v)
        {
            while (v >= 0x80)
            {
                buf.Add((byte)((v & 0x7F) | 0x80));
                v >>= 7;
            }
            buf.Add((byte)v);
        }

        private static uint ReadVarint(ref int i, byte[] b)
        {
            uint v = 0; int shift = 0;
            while (i < b.Length)
            {
                byte x = b[i++];
                v |= (uint)(x & 0x7F) << shift;
                if ((x & 0x80) == 0) break;
                shift += 7;
            }
            return v;
        }
    }
}
