
using Infision;
using Infision.MHCP;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Infision
{
public class HP60
{

        public static async Task Lissss()
        {


            const int port = 9900;
            const string ip = "192.168.1.100"; // tüm arayüzlerde dinle
            const string targetIP = "192.168.1.40"; // cihaz IP'si

            var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));
            CancellationToken ct = cts.Token;

            using var client = await listener.AcceptTcpClientAsync(); // parametresiz: geniş uyumluluk
            Console.WriteLine($"[+] Cihaz bağlandı: {client.Client.RemoteEndPoint}");

            using var stream = client.GetStream();

            // 1) Heartbeat (257) REQUEST
            var hbPayload = new HeartbeatCycleRequest { HeartbeatExpirationPeriodInSeconds = 5 }.ToByteArray();
            var hbHeader = new ProtocolHeader
            {
                RouteId = 0,
                MessageId = 257,
                CategoryId = 2,
                RequestResponse = RequestResponseTypeEnum.Request,
                SequenceNumber = (uint)MhcpWire.NextSeq()
            }.ToByteArray();
            await stream.WriteAsync(MhcpWire.Build(hbHeader, hbPayload), ct);

            // 3) DeviceInfo (258) REQUEST (payload yok)
            var devHeader = new ProtocolHeader
            {
                RouteId = 0,
                MessageId = 258,
                CategoryId = 2,
                RequestResponse = RequestResponseTypeEnum.Request,
                SequenceNumber = (uint)MhcpWire.NextSeq()
            }.ToByteArray();
            await stream.WriteAsync(MhcpWire.Build(devHeader, Array.Empty<byte>()), ct);

            // 4) 258 RESPONSE bekle → handshake tamam
            (ProtocolHeader devRespHeader, byte[] devRespPayload) =
            await MhcpClientHelpers.WaitForDeviceInfoResponseAsync(stream, TimeSpan.FromSeconds(40), ct);

            Console.WriteLine($"[+] DeviceInfo alındı. Payload uzunluğu: {devRespPayload.Length} bayt");











            // === 4) Hasta bilgisi güncelleme paketi (Frame 494) ===
            await Task.Delay(3000); // 3 saniye bekle

            var patient = new MhcpPacketBuilder.PatientInfo
            {
                Id = "123",
                DepartmentName = "ICU",
                BedNo = "B01",
                Pid = "P0001",
                VisitId = "V0001",
                LastName = "çolak",
                FirstName = "şerkan",
                Gender = 2,      // MALE
                Age = 9,
                AgeUnit = 2,     // YEARS
                BloodType = 2,   // O
                Physician = "DR",
                Diagnosis = "DX",
                Height = 120.5f,
                Weight = 35.2f,

                // AdmitDate = ... // isterseniz ekleyin
            };

            var bytes = MhcpPacketBuilder.BuildPatientPacket(messageId: 4100, sequenceNumber: 1, p: patient);
            // C# List<int> olarak görmek isterseniz:
            List<int> byteList = bytes.Select(b => (int)b).ToList();

            Console.WriteLine(string.Join(",", byteList));






            Console.WriteLine("[>] Hasta bilgisi paketi gönderildi!");





            // === Bitir ===
            client.Close();
            listener.Stop();
            Console.WriteLine("[x] Bağlantı kapatıldı.");


        }
}
}



