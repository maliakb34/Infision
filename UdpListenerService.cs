// ListenerStarterWorker.cs
using Infision.Configure;
using Infision.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Buffers;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace Infision;

public sealed class UdpListenerService : BackgroundService
{
    private readonly ILogger<UdpListenerService> _log;
    private readonly IKafkaProducer _producer;
    private readonly string _topic;
    private readonly int _port;
    private readonly IDiscoveryRegistry _registry;

    public UdpListenerService(ILogger<UdpListenerService> log, IKafkaProducer producer, IDiscoveryRegistry registry)
    {
        _log = log;
        _producer = producer;
        _topic = RootSetting.Roots.AppSettings.Kafka.TopicRaw;
        _port = RootSetting.Roots.AppSettings.NetworkSetting.UdpListenPort;
        _registry = registry;
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        // Socket tabanlı async I/O (await CPU'yu kilitlemez)
        using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(new IPEndPoint(IPAddress.Any, _port));
        socket.ReceiveBufferSize = 1 * 1024 * 1024; // 1MB (gerekirse artır)
        Inticators.UdpSocketRcvBufBytes = socket.ReceiveBufferSize;

        //_log.LogInformation("UDP listening on 0.0.0.0:{Port} (rcvbuf={Buf} bytes)", _port, socket.ReceiveBufferSize);

        EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
        const int BufSize = 4096; // payload’lar büyükse artır
        byte[] buf = ArrayPool<byte>.Shared.Rent(BufSize);

        try
        {
            while (!ct.IsCancellationRequested)
            {
                SocketReceiveMessageFromResult res;
                try
                {
                    res = await socket.ReceiveMessageFromAsync(
                        new ArraySegment<byte>(buf, 0, BufSize),
                        SocketFlags.None,
                        remote,
                        ct);
                }
                catch (OperationCanceledException) { break; }
                catch (Exception ex)
                {
                    Inticators.UdpError();
                    _log.LogError(ex, "UDP receive error");
                    continue;
                }

                if (res.ReceivedBytes <= 0) continue;

                var remoteEp = (IPEndPoint)res.RemoteEndPoint!;
                var key = $"{remoteEp.Address}:{remoteEp.Port}";
                var hex = ToHex(buf.AsSpan(0, res.ReceivedBytes));

                Inticators.UdpReceived();

                // discovery registry (non-blocking)
                var payload = buf.AsSpan(0, res.ReceivedBytes).ToArray();
                // Update the instantiation of DiscoveredDevice to use an object initializer with all required parameters.
                var devInfo = new DiscoveredDevice(
                   address: remoteEp.ToString(),
                   port: remoteEp.Port,       
                   protocol: "UDP",
                   seenAtUtc: DateTimeOffset.UtcNow,
                   lastPayload: payload
               );


                // Kafka: fire-and-forget (await yok)
                _ = _producer.ProduceAsync(_topic, key, JsonSerializer.Serialize(devInfo), ct).ContinueWith(t =>
                {
                    if (t.IsFaulted) Inticators.KafkaFailed();
                    else Inticators.KafkaDelivered();
                }, TaskScheduler.Default);

                Inticators.KafkaProduced();
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buf);
        }
    }

    // hızlı/allocation-light hex
    private static string ToHex(ReadOnlySpan<byte> data)
    {
        if (data.IsEmpty) return string.Empty;
        char[] chars = ArrayPool<char>.Shared.Rent(data.Length * 3);
        try
        {
            int pos = 0;
            for (int i = 0; i < data.Length; i++)
            {
                byte b = data[i];
                chars[pos++] = (char)((b >> 4) < 10 ? '0' + (b >> 4) : 'A' + ((b >> 4) - 10));
                chars[pos++] = (char)((b & 0xF) < 10 ? '0' + (b & 0xF) : 'A' + ((b & 0xF) - 10));
                if (i != data.Length - 1) chars[pos++] = ' ';
            }
            return new string(chars, 0, pos);
        }
        finally
        {
            ArrayPool<char>.Shared.Return(chars);
        }
    }
}
