using Infision.MHCP.Proto;
using System;
using System.Text;

namespace Infision.MHCP.Diagnostics
{
    internal static class ProtobufDumper
    {
        public static string Dump(ReadOnlySpan<byte> data)
        {
            var sb = new StringBuilder();
            DumpInto(sb, data, 0, 0);
            return sb.ToString();
        }

        private static void DumpInto(StringBuilder sb, ReadOnlySpan<byte> data, int indent, int depth)
        {
            if (depth > 5)
            {
                sb.Append(' ', indent).AppendLine("[depth limit reached]");
                return;
            }

            var reader = new ProtobufReader(data);
            while (!reader.EOF)
            {
                var (field, wireType) = reader.ReadKey();
                sb.Append(' ', indent).Append("field ").Append(field).Append(" (wire ").Append(wireType).Append("): ");
                switch (wireType)
                {
                    case 0: // varint
                        var v = reader.ReadVarint();
                        sb.AppendLine(v.ToString());
                        break;
                    case 1: // fixed64
                        var f64 = reader.ReadFixed64();
                        sb.AppendLine(f64.ToString());
                        break;
                    case 2: // length-delimited
                        var span = reader.ReadLengthDelimited();
                        sb.Append("len=").Append(span.Length);
                        if (LooksLikeText(span))
                        {
                            sb.Append(" text=\"").Append(Encoding.UTF8.GetString(span)).Append('"');
                        }
                        sb.AppendLine();
                        if (span.Length > 0)
                        {
                            DumpInto(sb, span, indent + 2, depth + 1);
                        }
                        break;
                    case 5: // fixed32
                        var f32 = reader.ReadFixed32();
                        sb.AppendLine(f32.ToString());
                        break;
                    default:
                        sb.AppendLine("[unsupported wire type]");
                        break;
                }
            }
        }

        private static bool LooksLikeText(ReadOnlySpan<byte> span)
        {
            if (span.Length == 0 || span.Length > 256)
                return false;

            int printable = 0;
            foreach (var b in span)
            {
                if (b == 0) return false;
                if (b == 0x0A || b == 0x0D || b == 0x09)
                {
                    printable++;
                    continue;
                }
                if (b >= 0x20 && b <= 0x7E)
                {
                    printable++;
                }
                else
                {
                    return false;
                }
            }
            return printable >= span.Length * 0.8;
        }
    }
}
