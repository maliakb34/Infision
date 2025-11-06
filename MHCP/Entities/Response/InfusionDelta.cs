using Infision.MHCP.Proto;
using System;

namespace Infision.MHCP.Entities.Response
{
    public sealed class InfusionDelta
    {
        public float? Rate { get; set; }               // field 1 (fixed32 -> float)
        public float? RemainVolume { get; set; }       // field 2 (fixed32)
        public float? CumulantInfused { get; set; }    // field 3 (fixed32)
        public uint? TimeRemaining { get; set; }       // field 4 (varint)
        public uint? StepNumber { get; set; }          // field 5 (varint)
        public uint? StepState { get; set; }           // field 6 (varint enum)
        public uint? DropRate { get; set; }            // field 7 (varint)
        public float? DoseRate { get; set; }           // field 8 (fixed32)
        public uint? InfusionInterval { get; set; }    // field 9 (varint)
        public float? PlasmaConc { get; set; }         // field 10 (fixed32)
        public float? EffectRoomConc { get; set; }     // field 11 (fixed32)
        public uint? ValidPressNumber { get; set; }    // field 12 (varint)
        public uint? InvalidPressNumber { get; set; }  // field 13 (varint)
        public uint? IntermissionTime { get; set; }    // field 14 (varint)
        public float? Pressure { get; set; }           // field 15 (fixed32)
        public uint? PressureUnit { get; set; }        // field 16 (varint)
        public uint? StepType { get; set; }            // field 17 (varint enum)
        public float? Dosed { get; set; }              // field 18 (fixed32)
        public float? VTBI { get; set; }               // field 19 (fixed32)
        public uint? WaitTime { get; set; }            // field 20 (varint)
        public string LoadingDoseUnit { get; set; }    // field 21 (string)

        internal static InfusionDelta Parse(ReadOnlySpan<byte> payload)
        {
            var r = new ProtobufReader(payload);
            var d = new InfusionDelta();
            while (!r.EOF)
            {
                var (f, wt) = r.ReadKey();
                switch (f)
                {
                    case 1: d.Rate = ReadFloat32(ref r, wt); break;
                    case 2: d.RemainVolume = ReadFloat32(ref r, wt); break;
                    case 3: d.CumulantInfused = ReadFloat32(ref r, wt); break;
                    case 4: d.TimeRemaining = wt == 0 ? r.ReadVarint() : null; break;
                    case 5: d.StepNumber = wt == 0 ? r.ReadVarint() : null; break;
                    case 6: d.StepState = wt == 0 ? r.ReadVarint() : null; break;
                    case 7: d.DropRate = wt == 0 ? r.ReadVarint() : null; break;
                    case 8: d.DoseRate = ReadFloat32(ref r, wt); break;
                    case 9: d.InfusionInterval = wt == 0 ? r.ReadVarint() : null; break;
                    case 10: d.PlasmaConc = ReadFloat32(ref r, wt); break;
                    case 11: d.EffectRoomConc = ReadFloat32(ref r, wt); break;
                    case 12: d.ValidPressNumber = wt == 0 ? r.ReadVarint() : null; break;
                    case 13: d.InvalidPressNumber = wt == 0 ? r.ReadVarint() : null; break;
                    case 14: d.IntermissionTime = wt == 0 ? r.ReadVarint() : null; break;
                    case 15: d.Pressure = ReadFloat32(ref r, wt); break;
                    case 16: d.PressureUnit = wt == 0 ? r.ReadVarint() : null; break;
                    case 17: d.StepType = wt == 0 ? r.ReadVarint() : null; break;
                    case 18: d.Dosed = ReadFloat32(ref r, wt); break;
                    case 19: d.VTBI = ReadFloat32(ref r, wt); break;
                    case 20: d.WaitTime = wt == 0 ? r.ReadVarint() : null; break;
                    case 21:
                        if (wt == 2)
                        {
                            var s = r.ReadLengthDelimited();
                            d.LoadingDoseUnit = System.Text.Encoding.UTF8.GetString(s);
                        }
                        else Skip(ref r, wt);
                        break;
                    default:
                        Skip(ref r, wt);
                        break;
                }
            }
            return d;
        }

        private static float? ReadFloat32(ref ProtobufReader r, int wt)
        {
            if (wt == 5)
            {
                var u = r.ReadFixed32();
                // Convert the 32-bit little-endian pattern to float without unsafe
                return BitConverter.Int32BitsToSingle(unchecked((int)u));
            }
            Skip(ref r, wt); return null;
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
