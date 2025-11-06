using Infision.MHCP.Proto;
using System;

namespace Infision.MHCP.Entities.Response
{
    public sealed class InfusionPeriodicEvent
    {
        public string DeviceSerialNumber { get; set; } = string.Empty;
        public long OccurrenceSeconds { get; set; }
        public int OccurrenceNanos { get; set; }
        public InfusionDelta Delta { get; set; } = new InfusionDelta();

        public static InfusionPeriodicEvent Parse(byte[] payload)
        {
            var ev = new InfusionPeriodicEvent();
            var r = new ProtobufReader(payload);
            while (!r.EOF)
            {
                var (field, wt) = r.ReadKey();
                if (field == 1 && wt == 2) // header
                {
                    var header = r.ReadLengthDelimited();
                    ParseHeader(header, ev);
                }
                else if (field == 2 && wt == 2) // infusionDelta
                {
                    var delta = r.ReadLengthDelimited();
                    ev.Delta = InfusionDelta.Parse(delta);
                }
                else
                {
                    Skip(ref r, wt);
                }
            }
            return ev;
        }

        private static void ParseHeader(ReadOnlySpan<byte> buf, InfusionPeriodicEvent ev)
        {
            var r = new ProtobufReader(buf);
            while (!r.EOF)
            {
                var (f, wt) = r.ReadKey();
                if (f == 1 && wt == 2) // sendingDeviceId
                {
                    var did = r.ReadLengthDelimited();
                    ParseDeviceIdentifier(did, ev);
                }
                else if (f == 2 && wt == 2) // occurrenceTimestamp (google.protobuf.Timestamp)
                {
                    var ts = r.ReadLengthDelimited();
                    ParseTimestamp(ts, ev);
                }
                else if (f == 3 && wt == 2) // SequenceIdentifier (ignore)
                {
                    r.ReadLengthDelimited();
                }
                else
                {
                    Skip(ref r, wt);
                }
            }
        }

        private static void ParseDeviceIdentifier(ReadOnlySpan<byte> buf, InfusionPeriodicEvent ev)
        {
            var r = new ProtobufReader(buf);
            while (!r.EOF)
            {
                var (f, wt) = r.ReadKey();
                switch (f)
                {
                    case 2: // serialNumber (string)
                        if (wt == 2)
                        {
                            var s = r.ReadLengthDelimited();
                            ev.DeviceSerialNumber = System.Text.Encoding.UTF8.GetString(s);
                        }
                        else Skip(ref r, wt);
                        break;
                    default:
                        // skip modelNumber(1), deviceType(3), chipId(4)
                        Skip(ref r, wt);
                        break;
                }
            }
        }

        private static void ParseTimestamp(ReadOnlySpan<byte> buf, InfusionPeriodicEvent ev)
        {
            var r = new ProtobufReader(buf);
            long seconds = 0; int nanos = 0;
            while (!r.EOF)
            {
                var (f, wt) = r.ReadKey();
                if (f == 1 && wt == 0) seconds = (long)r.ReadVarint64();
                else if (f == 2 && wt == 0) nanos = (int)r.ReadVarint();
                else Skip(ref r, wt);
            }
            ev.OccurrenceSeconds = seconds;
            ev.OccurrenceNanos = nanos;
        }

        private static void Skip(ref ProtobufReader r, int wt)
        {
            switch (wt)
            {
                case 0: r.ReadVarint(); break;
                case 1: r.ReadFixed64(); break;
                case 2: r.ReadLengthDelimited(); break;
                case 5: r.ReadFixed32(); break;
                default: throw new NotSupportedException($"Unsupported wire type {wt}");
            }
        }
    }
}

