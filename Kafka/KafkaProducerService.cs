using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Infision.Configure;

namespace Infision.Kafka
{

    public interface IKafkaProducer
    {
        Task ProduceAsync(string topic, string key, string value, CancellationToken ct = default);
    }

    public sealed class KafkaProducerService : IKafkaProducer, IDisposable
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducerService()
        {
            var conf = new ProducerConfig
            {
                BootstrapServers = Infision.Configure.RootSetting.Roots.AppSettings.Kafka.Bootstrap,
                Acks = Acks.All,
                EnableIdempotence = true,
                LingerMs = 10,

                CompressionType = CompressionType.Snappy,

            };
            _producer = new ProducerBuilder<string, string>(conf).Build();
        }


        public async Task ProduceAsync(string topic, string key, string value, CancellationToken ct = default)
        {
            try
            {
                var dr =  _producer.ProduceAsync(
                    topic,
                    new Message<string, string> { Key = key, Value = value },
                    ct);

                // Debug log


                // Flush ekle!
                _producer.Flush(TimeSpan.FromMilliseconds(50));
            }
            catch (ProduceException<string, string> e)
            {
                Console.WriteLine($"Kafka produce failed: {e}");
            }
        }


        public void Dispose() => _producer?.Dispose();
    }


}
