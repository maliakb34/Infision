using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infision.Kafka;

public class KafkaConsumerService : BackgroundService
{
    private readonly ILogger<KafkaConsumerService> _log;
    private readonly string _topic;
    private readonly string _bootstrapServers;
    private readonly string _groupId;

    public KafkaConsumerService(ILogger<KafkaConsumerService> log)
    {
        _log = log;
        _bootstrapServers = Infision.Configure.RootSetting.Roots.AppSettings.Kafka.Bootstrap;
        _topic = Infision.Configure.RootSetting.Roots.AppSettings.Kafka.TopicRaw;
        _groupId = "udp-monitor-group";
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = _bootstrapServers,
            GroupId = _groupId,
            AutoOffsetReset = AutoOffsetReset.Latest,
            EnableAutoCommit = false,              // kendimiz commit edeceğiz
            SocketKeepaliveEnable = true
        };

        using var consumer = new ConsumerBuilder<string, string>(config)
            // Atama anında her partisyonu "son" (Offset.End) konumuna getir
            .SetPartitionsAssignedHandler((c, parts) =>
            {
                _log.LogInformation("Assigned: {Parts}", string.Join(",", parts));
                var seekEnd = parts.Select(p => new TopicPartitionOffset(p, Offset.End)).ToList();
                return seekEnd; // ->   
            })
            .SetErrorHandler((_, e) => _log.LogError("Kafka error: {Reason}", e.Reason))
            .Build();

        consumer.Subscribe(_topic);
      //  _log.LogInformation("Kafka consumer subscribing '{Topic}' on {Servers}", _topic, _bootstrapServers);

        try
        {
            while (!ct.IsCancellationRequested)
            {
                // Timeout'lu poll: bloklanmayı gör
                var cr = consumer.Consume(TimeSpan.FromSeconds(0));
                if (cr is null) continue; // yeni mesaj yok

                if (cr.Message is not null)
                {
                    try
                    {
                        // === MESAJI İŞLE ===
                        //  _log.LogInformation("Latest msg {TP}@{Offset} Key={Key} Value={Value}",
                        //      cr.TopicPartition, cr.Offset.Value, cr.Message.Key, cr.Message.Value);

                        // İşlemin başarılıysa offset'i commit et → aynı grup bir daha okumaz
                        consumer.Commit(cr);


                    }
                    catch (Exception ex)
                    {
                        _log.LogError(ex, "Processing error, message will be retried (no commit).");
                        // commit ETME → tekrar okunur
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            _log.LogInformation("Kafka consumer stopped.");
        }
        finally
        {
            try { consumer.Close(); } catch { /* ignore */ }
        }
    }
}
