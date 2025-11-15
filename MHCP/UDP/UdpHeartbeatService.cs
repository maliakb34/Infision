using Infision.Configure;
using Infision.MHCP.UDP.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP.UDP
{
    public sealed class UdpHeartbeatService : IAsyncDisposable
    {
        private readonly UdpEventRequest _request;
        private readonly ILogger<UdpHeartbeatService> _logger;
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _monitors = new();
        private readonly TimeSpan _interval;

        public UdpHeartbeatService(
            UdpEventRequest request,
            ILogger<UdpHeartbeatService> logger,
            IOptions<NetworkSettings> options)
        {
            _request = request;
            _logger = logger;
            var settings = RootSetting.Roots?.AppSettings?.NetworkSetting ?? options.Value ?? new NetworkSettings();
            _interval = TimeSpan.FromMilliseconds(Math.Max(1000, settings.UdpBroadcastIntervalMs));
        }

        public void EnsureHeartbeat(IPEndPoint endpoint)
        {
            var key = endpoint.ToString();
            if (_monitors.ContainsKey(key))
                return;

            var cts = new CancellationTokenSource();
            if (_monitors.TryAdd(key, cts))
            {
                _logger.LogDebug("Starting UDP heartbeat for {Endpoint}", endpoint);
                _ = Task.Run(() => RunHeartbeatAsync(endpoint, cts.Token));
            }
            else
            {
                cts.Dispose();
            }
        }

        private async Task RunHeartbeatAsync(IPEndPoint endpoint, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var patient = new PatientStationInfo
                    {
                        HospitalId = "1306892806",
                        Name = "adem yeþilyurt",
                        Age = 55,
                        Sex = 1,
                        Height = 184.2f,
                        Weight = 88.0f,
                        PatientType = 1,
                        Department = "deneme",
                        Room = "odasý",
                        Bed = "6",
                        Advice = "Deneme"
                    };
                    var slotNumber = 0xFF; // MP60 referansýndaki transmit ID
                    await _request.SendPatientAsync(endpoint, patient, slotNumber, CancellationToken.None);

                    await _request.SendPatientInfoRequestAsync(endpoint, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (token.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to send heartbeat to {Endpoint}", endpoint);
                }

                try
                {
                    await Task.Delay(_interval, token).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (token.IsCancellationRequested)
                {
                    break;
                }
            }

            _logger.LogDebug("Stopping UDP heartbeat for {Endpoint}", endpoint);
        }

        public ValueTask DisposeAsync()
        {
            foreach (var (_, cts) in _monitors)
            {
                cts.Cancel();
                cts.Dispose();
            }

            _monitors.Clear();
            return ValueTask.CompletedTask;
        }
    }
}
