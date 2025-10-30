using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Hosting;

namespace Infision
{
    public class Inticators : BackgroundService
    {
        // UDP  
        private static long _udpReceived, _udpErrors, _udpAppDropped;
        private static int _udpSocketRcvBufBytes;
        public static int UdpSocketRcvBufBytes
        {
            get => Volatile.Read(ref _udpSocketRcvBufBytes);
            set => Volatile.Write(ref _udpSocketRcvBufBytes, value);
        }

        // Kafka  
        private static long _kafkaProduced, _kafkaDelivered, _kafkaFailed, _kafkaQueueFull;
        private static int _kafkaQueueMsgCount;
        private static long _kafkaQueueMsgBytes;
        private static int _kafkaTxMsgsPerSec;

        public static int KafkaQueueMsgCount
        {
            get => Volatile.Read(ref _kafkaQueueMsgCount);
            set => Volatile.Write(ref _kafkaQueueMsgCount, value);
        }

        public static long KafkaQueueMsgBytes
        {
            get => Interlocked.Read(ref _kafkaQueueMsgBytes);
            set => Interlocked.Exchange(ref _kafkaQueueMsgBytes, value);
        }

        public static int KafkaTxMsgsPerSec
        {
            get => Volatile.Read(ref _kafkaTxMsgsPerSec);
            set => Volatile.Write(ref _kafkaTxMsgsPerSec, value);
        }

        // ---- inc/dec helpers ----  
        public static void UdpReceived() => Interlocked.Increment(ref _udpReceived);
        public static void UdpError() => Interlocked.Increment(ref _udpErrors);
        public static void UdpAppDropped() => Interlocked.Increment(ref _udpAppDropped);

        public static void KafkaProduced() => Interlocked.Increment(ref _kafkaProduced);
        public static void KafkaDelivered() => Interlocked.Increment(ref _kafkaDelivered);
        public static void KafkaFailed() => Interlocked.Increment(ref _kafkaFailed);
        public static void KafkaQueueFull() => Interlocked.Increment(ref _kafkaQueueFull);

        public static (long udpRecv, long udpErr, long udpDrop,
                       long kProd, long kOk, long kFail, long kQfull) SnapshotTotals()
            => (Interlocked.Read(ref _udpReceived),
                Interlocked.Read(ref _udpErrors),
                Interlocked.Read(ref _udpAppDropped),
                Interlocked.Read(ref _kafkaProduced),
                Interlocked.Read(ref _kafkaDelivered),
                Interlocked.Read(ref _kafkaFailed),
                Interlocked.Read(ref _kafkaQueueFull));

        // librdkafka statistics JSON → seçtiğimiz alanlar  
        public static void UpdateFromProducerStats(string json)
        {
            try
            {
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("txmsgs", out var tx)) KafkaTxMsgsPerSec = tx.GetInt32();
                if (root.TryGetProperty("msg_cnt", out var mc)) KafkaQueueMsgCount = mc.GetInt32();
                if (root.TryGetProperty("msg_size", out var msz)) KafkaQueueMsgBytes = msz.GetInt64();
            }
            catch { /* ignore */ }
        }

        // Prometheus (opsiyonel; indicator servisinden kullanılabilir)  
        public static string ToPromText()
        {
            var (uR, uE, uD, kP, kOk, kFail, kQf) = SnapshotTotals();
            return
    $@"# HELP udp_received_total UDP ile alınan paket sayısı  
       # TYPE udp_received_total counter  
       udp_received_total {uR}  
       # HELP udp_errors_total UDP hata sayısı  
       # TYPE udp_errors_total counter  
       udp_errors_total {uE}  
       # HELP udp_app_dropped_total Uygulama seviyesinde düşürülen UDP paket sayısı  
       # TYPE udp_app_dropped_total counter  
       udp_app_dropped_total {uD}  
       # HELP kafka_produced_total Kafka'ya üretim girişimi  
       # TYPE kafka_produced_total counter  
       kafka_produced_total {kP}  
       # HELP kafka_delivered_total Başarıyla teslim edilen Kafka mesajları  
       # TYPE kafka_delivered_total counter  
       kafka_delivered_total {kOk}  
       # HELP kafka_failed_total Kafka teslimat hataları  
       # TYPE kafka_failed_total counter  
       kafka_failed_total {kFail}  
       # HELP kafka_queuefull_total Producer local queue full sayısı  
       # TYPE kafka_queuefull_total counter  
       kafka_queuefull_total {kQf}  
       # HELP kafka_queue_msgs Producer local queue mesaj adedi  
       # TYPE kafka_queue_msgs gauge  
       kafka_queue_msgs {KafkaQueueMsgCount}  
       # HELP kafka_queue_bytes Producer local queue bayt  
       # TYPE kafka_queue_bytes gauge  
       kafka_queue_bytes {KafkaQueueMsgBytes}  
       # HELP kafka_txmsgs_per_sec Librdkafka txmsgs (msg/s)  
       # TYPE kafka_txmsgs_per_sec gauge  
       kafka_txmsgs_per_sec {KafkaTxMsgsPerSec}  
       # HELP udp_socket_rcvbuf_bytes UDP socket receive buffer size  
       # TYPE udp_socket_rcvbuf_bytes gauge  
       udp_socket_rcvbuf_bytes {UdpSocketRcvBufBytes}  
       ";
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Implementation for the background service logic  
            return Task.CompletedTask;
        }
    }
}
