using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infision
{
    public  class MP60RealTimeData
    {
        static int listenPort = 26800; // Cihazın default UDP portu
        static string deviceIp = "192.168.1.30"; // Cihaz IP'si — ayarlarda sabitlenmeli


        public static async Task RunServer()
        {

            Console.WriteLine($"[UDP SERVER] Başlatılıyor... Port: {listenPort}");

             UdpClient udp = new UdpClient(listenPort);

            await Task.Delay(1000);

            await SendPatientInfoRequestAsync();
            while (true)
            {
                Task.Run(async () => ListenLoop(udp));


            }
           
        }

        private static async Task ListenLoop(UdpClient udp)
        {
            Console.WriteLine($"[UDP Dinleyici] Port {listenPort} üzerinden dinleniyor...");

           
                try
                {
                    UdpReceiveResult result = await udp.ReceiveAsync();
                    byte[] data = result.Buffer;
                    ushort cmd = BitConverter.ToUInt16(new byte[] { data[1], data[2] }, 0);
                    Console.WriteLine($"[RECV] CmdCode: 0x{cmd:X4} ({data.Length} byte)");
                    Console.WriteLine($"[RECV] Uzunluk: {data.Length} byte");



                    switch (cmd)
                    {
                        case 0x0360: ParseRealTimeData(data);  break;
                        case 0x8306: ParsePatientInfo(data); break;
                        default: Console.WriteLine("Bilinmeyen komut."); break;

                    }
              
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[HATA] Dinleme döngüsü hatası: {ex.Message}");
                    await Task.Delay(1000);
                }
            }
       


        public static async Task SendPatientInfoRequestAsync()
        {
            using UdpClient udp = new UdpClient();
            IPEndPoint deviceEndpoint = new IPEndPoint(IPAddress.Parse(deviceIp), listenPort);

            byte[] packet = new byte[11];
            packet[0] = 0xFA;               // Head
            packet[1] = 0x06; packet[2] = 0x03; // CmdCode = 0x0306
            packet[3] = 0x00; packet[4] = 0x00; // Data Length = 0
            packet[5] = 0xFF; //Try this if no response.

            // Transmit ID, Auth, Reserve = 0
            byte checksum = 0;
            for (int i = 0; i < 10; i++)
                checksum += packet[i];

            packet[10] = checksum;

            await udp.SendAsync(packet, packet.Length, deviceEndpoint);
            Console.WriteLine("[SEND] Hasta bilgisi isteği (0x0306) gönderildi");
        }

        public static void ParsePatientInfo(byte[] data)
        {
            int o = 11;
            string hospitalId = Encoding.ASCII.GetString(data, o, 19).Trim(); o += 19;
            string name = Encoding.ASCII.GetString(data, o, 19).Trim(); o += 19;
            byte sex = data[o++];
            byte age = data[o++];
            float height = BitConverter.ToSingle(data, o); o += 4;
            float weight = BitConverter.ToSingle(data, o); o += 4;
            byte patientType = data[o++];
            string department = Encoding.ASCII.GetString(data, o, 19).Trim(); o += 19;
            string room = Encoding.ASCII.GetString(data, o, 11).Trim(); o += 11;
            string bed = Encoding.ASCII.GetString(data, o, 7).Trim(); o += 7;
            string advice = Encoding.ASCII.GetString(data, o, 129).Trim(); o += 129;

            Console.WriteLine("\n👤 [HASTA BİLGİSİ]");
            Console.WriteLine($"🏥 Hastane ID : {hospitalId}");
            Console.WriteLine($"👤 Ad Soyad   : {name}");
            Console.WriteLine($"🚻 Cinsiyet   : {(sex == 1 ? "Erkek" : sex == 2 ? "Kadın" : "Bilinmiyor")}");
            Console.WriteLine($"🔢 Yaş        : {age}");
            Console.WriteLine($"📏 Boy        : {height} cm");
            Console.WriteLine($"⚖️  Kilo       : {weight} kg");
            Console.WriteLine($"🧒 Tip        : {(patientType == 1 ? "Bebek" : patientType == 2 ? "Çocuk" : "Yetişkin")}");
            Console.WriteLine($"🏨 Departman  : {department} | 🚪 Oda: {room} | 🛏 Yatak: {bed}");
            Console.WriteLine($"📋 Not        : {advice}\n");
        }

        public static void ParseRealTimeData(byte[] data)
        {
            int o = 11;
            string serial = Encoding.ASCII.GetString(data, o, 19).Trim(); o += 19;
            byte deviceType = data[o++];
            string model = Encoding.ASCII.GetString(data, o, 19).Trim(); o += 19;
            string workstation = Encoding.ASCII.GetString(data, o, 19).Trim(); o += 19;
            string department = Encoding.ASCII.GetString(data, o, 19).Trim(); o += 19;
            string room = Encoding.ASCII.GetString(data, o, 11).Trim(); o += 11;
            string bed = Encoding.ASCII.GetString(data, o, 7).Trim(); o += 7;
            byte state = data[o++];
            string drug = Encoding.UTF8.GetString(data, o, 25).Trim(); o += 25;
            byte mode = data[o++];
            float vtbi = BitConverter.ToSingle(data, o); o += 4;
            float rate = BitConverter.ToSingle(data, o); o += 4;
            uint infusedTime = BitConverter.ToUInt32(data, o); o += 4;
            uint remainingTime = BitConverter.ToUInt32(data, o); o += 4;
            float infused = BitConverter.ToSingle(data, o); o += 4;
            float remaining = BitConverter.ToSingle(data, o); o += 4;
            uint alarm = BitConverter.ToUInt32(data, o); o += 4;

            Console.WriteLine("\n📡 [GERÇEK ZAMANLI VERİ]");
            Console.WriteLine($"💊 İlaç       : {drug}");
            Console.WriteLine($"🚀 Hız        : {rate} ml/h");
            Console.WriteLine($"📦 VTBI       : {vtbi} ml");
            Console.WriteLine($"🧪 Verilen    : {infused} ml | Kalan: {remaining} ml");
            Console.WriteLine($"⏱ Süre        : {infusedTime}s | Kalan Süre: {remainingTime}s");
            Console.WriteLine($"🔔 Alarm      : 0x{alarm:X8}\n");
        }

    }
}
