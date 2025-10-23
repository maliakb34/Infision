using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Sex : uint { Unknown = 0, Male = 1, Female = 2 }
public enum BloodType : uint { Unknown = 0, O = 1, A = 2, AB = 3, B = 4 }

namespace Infision
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public enum Sex : uint { Unknown = 0, Male = 1, Female = 2 }
    public enum BloodType : uint { Unknown = 0, O = 1, A = 2, AB = 3, B = 4 }

    public sealed class PatientModel
    {
        public string FirstName { get; set; } = "";   // field 7
        public string LastName { get; set; } = "";   // field 6
        public string PatientId { get; set; } = "";   // field 4
        public uint Age { get; set; }         // field 9
        public Sex Sex { get; set; }         // field 10
        public float WeightKg { get; set; }         // field 12 (float32)
        public float HeightCm { get; set; }         // field 11 (float32)
        public BloodType Blood { get; set; }         // field 13
        public string Department { get; set; } = "";  // field 2
        public string Room { get; set; } = "";   // field 3
        public uint BedNo { get; set; }         // field 8
    }

    public static class PatientCodec
    {
        // ==== Protobuf-lite helpers ====
        const int WT_Varint = 0;
        const int WT_Fixed64 = 1;
        const int WT_Length = 2;
        const int WT_Fixed32 = 5;

        static void WriteVarint(List<byte> dst, ulong v)
        {
            while (true)
            {
                byte b = (byte)(v & 0x7F);
                v >>= 7;
                if (v == 0) { dst.Add(b); break; }
                dst.Add((byte)(b | 0x80));
            }
        }

        static ulong ReadVarint(byte[] src, ref int i)
        {
            int shift = 0;
            ulong val = 0;
            while (true)
            {
                if (i >= src.Length) throw new IndexOutOfRangeException("Varint overrun");
                byte b = src[i++];
                val |= (ulong)(b & 0x7F) << shift;
                if ((b & 0x80) == 0) break;
                shift += 7;
                if (shift > 63) throw new FormatException("Varint too long");
            }
            return val;
        }

        static void WriteTag(List<byte> dst, int fieldNo, int wireType)
        {
            ulong tag = (ulong)((fieldNo << 3) | wireType);
            WriteVarint(dst, tag);
        }

        static (int fieldNo, int wireType) ReadTag(byte[] src, ref int i)
        {
            ulong tag = ReadVarint(src, ref i);
            int wt = (int)(tag & 0x07);
            int fn = (int)(tag >> 3);
            return (fn, wt);
        }

        static void WriteString(List<byte> dst, int fieldNo, string s)
        {
            WriteTag(dst, fieldNo, WT_Length);
            var bytes = Encoding.UTF8.GetBytes(s ?? "");
            WriteVarint(dst, (ulong)bytes.Length);
            dst.AddRange(bytes);
        }

        static string ReadString(byte[] src, ref int i)
        {
            ulong len = ReadVarint(src, ref i);
            int L = (int)len;
            if (i + L > src.Length) throw new IndexOutOfRangeException("String overrun");
            string s = Encoding.UTF8.GetString(src, i, L);
            i += L;
            return s;
        }

        static void WriteUInt32(List<byte> dst, int fieldNo, uint v)
        {
            WriteTag(dst, fieldNo, WT_Varint);
            WriteVarint(dst, v);
        }

        static uint ReadUInt32(byte[] src, ref int i)
        {
            return (uint)ReadVarint(src, ref i);
        }

        static void WriteFloat(List<byte> dst, int fieldNo, float f)
        {
            WriteTag(dst, fieldNo, WT_Fixed32);
            var bits = BitConverter.SingleToInt32Bits(f);
            // little-endian
            dst.Add((byte)(bits & 0xFF));
            dst.Add((byte)((bits >> 8) & 0xFF));
            dst.Add((byte)((bits >> 16) & 0xFF));
            dst.Add((byte)((bits >> 24) & 0xFF));
        }

        static float ReadFloat(byte[] src, ref int i)
        {
            if (i + 4 > src.Length) throw new IndexOutOfRangeException("Float overrun");
            int bits = src[i] | (src[i + 1] << 8) | (src[i + 2] << 16) | (src[i + 3] << 24);
            i += 4;
            return BitConverter.Int32BitsToSingle(bits);
        }

        // ==== Patient (field numbers sabit) ====
        public static byte[] BuildPatient(PatientModel m)
        {
            var o = new List<byte>(128);
            // 1: uid/sid gibi 32 byte'lýk alan (opsiyonel). Mevcut çerçeveden koruyacaðýz; burada yazmýyoruz.
            // 2: Department
            if (!string.IsNullOrEmpty(m.Department)) WriteString(o, 2, m.Department);
            // 3: Room
            if (!string.IsNullOrEmpty(m.Room)) WriteString(o, 3, m.Room);
            // 4: PatientId (Hast No)
            if (!string.IsNullOrEmpty(m.PatientId)) WriteString(o, 4, m.PatientId);
            // 5: device/vendor id (opsiyonel)
            // 6: LastName
            if (!string.IsNullOrEmpty(m.LastName)) WriteString(o, 6, m.LastName);
            // 7: FirstName
            if (!string.IsNullOrEmpty(m.FirstName)) WriteString(o, 7, m.FirstName);
            // 8: BedNo
            WriteUInt32(o, 8, m.BedNo);
            // 9: Age
            WriteUInt32(o, 9, m.Age);
            // 10: Sex
            WriteUInt32(o, 10, (uint)m.Sex);
            // 11: HeightCm
            WriteFloat(o, 11, m.HeightCm);
            // 12: WeightKg
            WriteFloat(o, 12, m.WeightKg);
            // 13: Blood
            WriteUInt32(o, 13, (uint)m.Blood);
            return o.ToArray();
        }

        public static PatientModel ParsePatient(byte[] src, int start, int len, out int consumed)
        {
            var m = new PatientModel();
            int i = start;
            int end = start + len;

            while (i < end)
            {
                var (fn, wt) = ReadTag(src, ref i);
                switch (wt)
                {
                    case WT_Length:
                        {
                            ulong L = ReadVarint(src, ref i);
                            int Li = (int)L;
                            if (i + Li > end) throw new IndexOutOfRangeException("LD overrun");
                            if (fn == 2) m.Department = Encoding.UTF8.GetString(src, i, Li);
                            else if (fn == 3) m.Room = Encoding.UTF8.GetString(src, i, Li);
                            else if (fn == 4) m.PatientId = Encoding.UTF8.GetString(src, i, Li);
                            else if (fn == 6) m.LastName = Encoding.UTF8.GetString(src, i, Li);
                            else if (fn == 7) m.FirstName = Encoding.UTF8.GetString(src, i, Li);
                            // diðer length-delimited alanlar (1,5 gibi) atlanýr
                            i += Li;
                            break;
                        }
                    case WT_Varint:
                        {
                            uint v = (uint)ReadVarint(src, ref i);
                            if (fn == 8) m.BedNo = v;
                            else if (fn == 9) m.Age = v;
                            else if (fn == 10) m.Sex = (Sex)v;
                            else if (fn == 13) m.Blood = (BloodType)v;
                            // diðer varintler atlanýr
                            break;
                        }
                    case WT_Fixed32:
                        {
                            float f = ReadFloat(src, ref i);
                            if (fn == 11) m.HeightCm = f;
                            else if (fn == 12) m.WeightKg = f;
                            break;
                        }
                    case WT_Fixed64:
                        {
                            // atla (timestamp vs)
                            i += 8;
                            break;
                        }
                    default:
                        throw new NotSupportedException($"Unsupported wireType {wt} at {i}");
                }
            }

            consumed = i - start;
            return m;
        }
    }

    public static class FramePatcher
    {
        // Basit bir "hasta bloðunu bul" yöntemi:
        //  - Hasta bloðu "0x0A 0x20 <32 ASCII hex>" + ardýndan 0x12,0x02,"MA" ile baþlýyor (senin frame’de öyle).
        //  - Bu imzayý bulup, sonrasý patient alanlarýný parse ediyoruz.
        //  - Yeniden encode edip ayný yere koyuyoruz; paket iç uzunluðu (2 bayt LE) güncelleniyor.
        //
        // Not: Magic 0xFA 0x05, ardýndan 2-bayt cmd (LE), 2-bayt len (LE) desenini koruyoruz.
        public static bool TryPatchPatient(byte[] frame, PatientModel newValues, out byte[] patched)
        {
            patched = null;

            // 1) App payload baþlangýcý: 0xFA 0x05 deseni
            int fa = IndexOf(frame, new byte[] { 0xFA, 0x05 });
            if (fa < 0) return false;

            int cmdOff = fa + 2;              // 2 bayt (cmd LE)
            int lenOff = fa + 4;              // 2 bayt (length LE)
            if (lenOff + 1 >= frame.Length) return false;

            int appLen = frame[lenOff] | (frame[lenOff + 1] << 8);
            int appStart = lenOff + 2;
            int appEnd = appStart + appLen;
            if (appEnd > frame.Length) return false;

            // 2) Patient alaný imzasýný bul (0x0A 0x20 + 32 hex + 0x12 0x02 'M' 'A')
            int patStart = FindPatientStart(frame, appStart, appEnd);
            if (patStart < 0) return false;

            // 3) Patient uzunluðunu tahmin: bir sonraki header/tag’a kadar
            // Burada kaba bir yaklaþým: patient alaný genelde paket sonuna kadar gidiyor,
            // ama güvenli olmak için geri kalan app alanýnýn boyutunu kullanacaðýz.
            int patLen = appEnd - patStart;

            // 4) Parse et (mevcut deðerleri okuyalým)
            var parsed = PatientCodec.ParsePatient(frame, patStart, patLen, out int consumed);

            // 5) "uid"/device alanýný korumak istiyorsan, Parse içinde length-delimited fn=1/5’i atlamýþ olduk — sorun deðil.

            // 6) Yeni patient bytes oluþtur
            var built = PatientCodec.BuildPatient(newValues);

            // 7) Patchle
            var outBuf = new List<byte>(frame.Length + Math.Max(0, built.Length - consumed));
            outBuf.AddRange(frame.Take(patStart));
            outBuf.AddRange(built);
            outBuf.AddRange(frame.Skip(patStart + consumed));

            // 8) Ýç uzunluðu güncelle (LE)
            int newAppLen = appLen - consumed + built.Length;
            outBuf[lenOff] = (byte)(newAppLen & 0xFF);
            outBuf[lenOff + 1] = (byte)((newAppLen >> 8) & 0xFF);

            // 9) (Opsiyonel) CRC/Checksum alaný varsa hesapla — stub:
            // TryFixCrc16(outBuf);  // util/protokol gelince dolduracaðýz.

            patched = outBuf.ToArray();
            return true;
        }

        static int IndexOf(byte[] hay, byte[] needle)
        {
            for (int i = 0; i <= hay.Length - needle.Length; i++)
            {
                bool ok = true;
                for (int j = 0; j < needle.Length; j++)
                    if (hay[i + j] != needle[j]) { ok = false; break; }
                if (ok) return i;
            }
            return -1;
        }

        static bool IsAsciiHex(byte b) =>
            (b >= (byte)'0' && b <= (byte)'9') ||
            (b >= (byte)'A' && b <= (byte)'F');

        static int FindPatientStart(byte[] buf, int start, int end)
        {
            for (int i = start; i < end - 40; i++)
            {
                if (buf[i] == 0x0A && buf[i + 1] == 0x20)
                {
                    bool ok = true;
                    for (int k = 0; k < 32; k++)
                    {
                        if (!IsAsciiHex(buf[i + 2 + k])) { ok = false; break; }
                    }
                    if (!ok) continue;
                    // 32 hex’ten sonra 0x12 0x02 'M' 'A' olmalý (senin örneðinde böyleydi)
                    int j = i + 2 + 32;
                    if (j + 3 < end && buf[j] == 0x12 && buf[j + 1] == 0x02 && buf[j + 2] == (byte)'M' && buf[j + 3] == (byte)'A')
                        return i; // patient start burada
                }
            }
            return -1;
        }
    }

}