using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infision
{
    public class MP60
    {
        // sabitler (referans frame ile uyumlu)
        const int O_HEADERLAST = 10;
        const int O_HOSP = 11; const int L_HOSP = 19;
        const int O_NAME = O_HOSP + L_HOSP; const int L_NAME = 19;
        const int O_AGE = O_NAME + L_NAME;               // base offset for AGE
        const int O_SEX = O_AGE + 1;                      // base offset for SEX area
        const int O_HEIGHT = O_SEX + 1; const int L_HEIGHT = 4;
        const int O_WEIGHT = O_HEIGHT + L_HEIGHT; const int L_WEIGHT = 4;
        const int O_PTYPE = O_WEIGHT + L_WEIGHT;
        const int O_DEPT = O_PTYPE + 1; const int L_DEPT = 19; // bölüm
        const int O_ROOM = O_DEPT + L_DEPT; const int L_ROOM = 11;
        const int O_BED = O_ROOM + L_ROOM; const int L_BED = 7; // yatak no
        const int O_ADVICE = O_BED + L_BED; const int L_ADVICE = 129;

        // detected positions (önceki tespitlere göre)
        const int AGE_POS = O_AGE + 1;     // numeric byte position for AGE
        const int SEX_POS = O_SEX - 1;     // numeric byte position for SEX
 
     public   static async Task<int> Sendpatientinfo()
        {
            // referans hex (Wireshark'tan aldığın çalışan paket)
            string refHex =
              "fa0903d700ff00000000223132333400000000000000000000000000000068790000000000000000000000000000000000002c00002e430000a8420049435500000000000000000000000000000000000000000000000000000033000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            byte[] reference;
            try { reference = HexToBytes(refHex); }
            catch (Exception ex) { Console.WriteLine("refHex parse hatası: " + ex.Message); return 1; }

            // hedef cihaz (kendi ağına göre değiştir)
            string deviceIp = "192.168.1.40";
            int devicePort = 26800;

            // yazılacak değerler (burayı değiştir)
            string hospitalNo = "1111";           // HASTA / HOSPITAL NO (ASCII, max L_HOSP)
            string deptToSet = "ICU";            // BÖLÜM (ASCII, max L_DEPT)
            string roomToSet = "f";           // O_ROOM (ASCII, max L_ROOM) - isteğe bağlı
            string bedToSet = "5";              // YATAK NO (ASCII, max L_BED)
            string nameToSet = "de";    // NAME (ASCII, max L_NAME)
            int ageToSet = 33;               // AGE (numeric byte)
            int sexToSet = 0;                // SEX (numeric byte)
            float weightToSetF = 11.0f;            // WEIGHT as float32 LE
            float heightToSet = 181.2f;           // HEIGHT as float32 LE

            bool actuallySend = true; // true = gönder, false = dry-run (sadece konsol)

            // clone ref
            var buf = (byte[])reference.Clone();

            // 0) HOSPITAL NO (ASCII, fixed length L_HOSP)
            PutAsciiFixed(buf, O_HOSP, L_HOSP, hospitalNo);
            Console.WriteLine($"HOSPITAL_NO -> \"{hospitalNo}\" @0x{O_HOSP:X} (len {L_HOSP})");

            // 0.5) DEPT (ASCII, fixed length L_DEPT)
            PutAsciiFixed(buf, O_DEPT, L_DEPT, deptToSet);
            Console.WriteLine($"DEPT -> \"{deptToSet}\" @0x{O_DEPT:X} (len {L_DEPT})");

            // 0.75) ROOM (ASCII, fixed length L_ROOM)
            PutAsciiFixed(buf, O_ROOM, L_ROOM, roomToSet);
            Console.WriteLine($"ROOM -> \"{roomToSet}\" @0x{O_ROOM:X} (len {L_ROOM})");

            // 0.9) BED (ASCII, fixed length L_BED)
            PutAsciiFixed(buf, O_BED, L_BED, bedToSet);
            Console.WriteLine($"BED -> \"{bedToSet}\" @0x{O_BED:X} (len {L_BED})");

            // 1) NAME
            PutAsciiFixed(buf, O_NAME, L_NAME, nameToSet);
            Console.WriteLine($"NAME -> \"{nameToSet}\" @0x{O_NAME:X}");

            // 2) AGE numeric byte
            if (AGE_POS >= 0 && AGE_POS < buf.Length)
            {
                buf[AGE_POS] = (byte)(ageToSet & 0xFF);
                Console.WriteLine($"AGE -> {ageToSet} written as 0x{buf[AGE_POS]:X2} @0x{AGE_POS:X}");
            }
            else Console.WriteLine("AGE_POS out of range!");

            // 3) SEX numeric byte
            if (SEX_POS >= 0 && SEX_POS < buf.Length)
            {
                buf[SEX_POS] = (byte)(sexToSet & 0xFF);
                Console.WriteLine($"SEX -> {sexToSet} written as 0x{buf[SEX_POS]:X2} @0x{SEX_POS:X}");
            }
            else Console.WriteLine("SEX_POS out of range!");

            // 4) WEIGHT : float32 little-endian at O_WEIGHT
            if (O_WEIGHT >= 0 && O_WEIGHT + 3 < buf.Length)
            {
                var fbytesW = BitConverter.GetBytes(weightToSetF); // float32 LE
                Buffer.BlockCopy(fbytesW, 0, buf, O_WEIGHT, 4);
                Console.WriteLine($"WEIGHT -> {weightToSetF} written as float32 LE bytes @0x{O_WEIGHT:X}: {ToHex(buf, O_WEIGHT, 4)}");
            }
            else Console.WriteLine("O_WEIGHT out of range!");

            // 5) HEIGHT : float32 little-endian at O_HEIGHT
            if (O_HEIGHT >= 0 && O_HEIGHT + 3 < buf.Length)
            {
                var fbytesH = BitConverter.GetBytes(heightToSet);
                Buffer.BlockCopy(fbytesH, 0, buf, O_HEIGHT, 4);
                Console.WriteLine($"HEIGHT -> {heightToSet} written as float32 LE bytes @0x{O_HEIGHT:X}: {ToHex(buf, O_HEIGHT, 4)}");
            }
            else Console.WriteLine("O_HEIGHT out of range!");

            // 6) recalc header[10]
            RecalculateHeaderLast(buf);
            Console.WriteLine($"header[10] after recalc = 0x{buf[O_HEADERLAST]:X2}");

            // 7) dump key regions
            Console.WriteLine("\n--- Field dumps ---");
            Console.WriteLine($"HOSP : 0x{O_HOSP:X3}-0x{O_HOSP + L_HOSP - 1:X3}: {ToHex(buf, O_HOSP, L_HOSP)} => \"{GetAscii(buf, O_HOSP, L_HOSP)}\"");
            Console.WriteLine($"DEPT : 0x{O_DEPT:X3}-0x{O_DEPT + L_DEPT - 1:X3}: {ToHex(buf, O_DEPT, L_DEPT)} => \"{GetAscii(buf, O_DEPT, L_DEPT)}\"");
            Console.WriteLine($"ROOM : 0x{O_ROOM:X3}-0x{O_ROOM + L_ROOM - 1:X3}: {ToHex(buf, O_ROOM, L_ROOM)} => \"{GetAscii(buf, O_ROOM, L_ROOM)}\"");
            Console.WriteLine($"BED  : 0x{O_BED:X3}-0x{O_BED + L_BED - 1:X3}: {ToHex(buf, O_BED, L_BED)} => \"{GetAscii(buf, O_BED, L_BED)}\"");
            Console.WriteLine($"NAME : 0x{O_NAME:X3}-0x{O_NAME + L_NAME - 1:X3}: {ToHex(buf, O_NAME, L_NAME)} => \"{GetAscii(buf, O_NAME, L_NAME)}\"");
            Console.WriteLine($"AGE  : 0x{AGE_POS:X} => 0x{buf[AGE_POS]:X2}");
            Console.WriteLine($"SEX  : 0x{SEX_POS:X} => 0x{buf[SEX_POS]:X2}");
            Console.WriteLine($"WEIGHT: 0x{O_WEIGHT:X3}-0x{O_WEIGHT + L_WEIGHT - 1:X3}: {ToHex(buf, O_WEIGHT, L_WEIGHT)}");
            Console.WriteLine($"HEIGHT: 0x{O_HEIGHT:X3}-0x{O_HEIGHT + L_HEIGHT - 1:X3}: {ToHex(buf, O_HEIGHT, L_HEIGHT)}");

            Console.WriteLine("\nPayload (hex single-line):");
            Console.WriteLine(ToHexSingleLine(buf));
            Console.WriteLine();

            // 8) send if requested
            if (actuallySend)
            {
                using var udp = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
                udp.Connect(deviceIp, devicePort);
                try
                {
                    await udp.SendAsync(buf, buf.Length);
                    Console.WriteLine($"Paket gönderildi -> {deviceIp}:{devicePort} (len={buf.Length})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Gönderme hatası: " + ex.Message);
                }
             }
            else
            {
                Console.WriteLine("actuallySend=false; paket gönderilmedi (dry-run).");
            }

            Console.WriteLine("Bitti. Cihazda hospital/dept/room/bed/name/age/sex/height/weight görünümünü bildir.");
            return 0;
        }


        static void RecalculateHeaderLast(byte[] payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));
            if (O_HEADERLAST < 0 || O_HEADERLAST >= payload.Length) throw new ArgumentOutOfRangeException(nameof(payload));
            int sum = 0;
            for (int i = 0; i < payload.Length; i++) { if (i == O_HEADERLAST) continue; unchecked { sum += payload[i]; } }
            payload[O_HEADERLAST] = (byte)(sum & 0xFF);
        }

        static void PutAsciiFixed(byte[] buf, int offset, int len, string text)
        {
            if (offset < 0 || len < 0 || offset + len > buf.Length) throw new ArgumentOutOfRangeException(nameof(len));
            Array.Clear(buf, offset, len);
            var b = Encoding.ASCII.GetBytes(text);
            Buffer.BlockCopy(b, 0, buf, offset, Math.Min(b.Length, len));
        }

        static string ToHexSingleLine(byte[] data)
        {
            var sb = new StringBuilder(data.Length * 2);
            foreach (var b in data) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        static string ToHex(byte[] a, int off, int len)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < len; i++) sb.AppendFormat("{0:x2} ", a[off + i]);
            return sb.ToString().TrimEnd();
        }

        static string GetAscii(byte[] buf, int offset, int len)
        {
            try { return Encoding.ASCII.GetString(buf, offset, len).TrimEnd('\0'); }
            catch { return ""; }
        }

        static byte[] HexToBytes(string hex)
        {
            hex = hex.Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("-", "");
            if ((hex.Length % 2) != 0) throw new ArgumentException("Hex string length must be even.");
            var bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++) bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return bytes;
        }
    }



}
