using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public sealed class ConsumerService : BackgroundService
{
    private readonly ILogger<ConsumerService> _log;
    private readonly string _topic;
    private readonly string _bootstrapServers;
    private readonly string _groupId = "udp-monitor-group";

    public ConsumerService(ILogger<ConsumerService> log)
    {
        _log = log;
        _bootstrapServers = Infision.Configure.RootSetting.Roots.AppSettings.Kafka.Bootstrap;
        _topic = Infision.Configure.RootSetting.Roots.AppSettings.Kafka.UDPTopicRaw;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // >>> Kritik nokta: LongRunning -> özel bir dedicated thread açar
        return Task.Factory.StartNew(
            () => RunConsumerLoop(stoppingToken),
            stoppingToken,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default
        );
    }

    private void RunConsumerLoop(CancellationToken ct)
    {
        var cfg = new ConsumerConfig
        {
            BootstrapServers = _bootstrapServers,
            GroupId = _groupId,
            AutoOffsetReset = AutoOffsetReset.Latest,
            EnableAutoCommit = false,
            SocketKeepaliveEnable = true
        };

        using var consumer = new ConsumerBuilder<string, string>(cfg)
            .SetPartitionsAssignedHandler((_, parts) => parts.Select(p => new TopicPartitionOffset(p, Offset.End)))
            .SetErrorHandler((_, e) => _log.LogError("Kafka error: {Reason}", e.Reason))
            .Build();

        consumer.Subscribe(_topic);
        _log.LogInformation("Kafka consumer started. topic={Topic} servers={Servers}", _topic, _bootstrapServers);

        try
        {
            while (!ct.IsCancellationRequested)
            {
                // Bloklayan, ama özel thread'de olduğu için ThreadPool'ı kilitlemez
                var cr = consumer.Consume(ct);
                if (cr?.Message is null) continue;

                try
                {
                    // … mesajı işle …
                    consumer.Commit(cr);
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, "Processing error. Not committing.");
                }
            }
        }
        catch (OperationCanceledException)
        {
            _log.LogInformation("Kafka consumer stopping...");
        }
        finally
        {
            try { consumer.Close(); } catch { /* ignore */ }
            _log.LogInformation("Kafka consumer closed.");
        }
    }
}
