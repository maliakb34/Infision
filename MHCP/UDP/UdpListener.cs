using Infision;
using Infision.Configure;
using Infision.MHCP.UDP.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP.UDP
{
    public sealed class UdpListener
    {
        private readonly ILogger<UdpListener> _logger;
        private readonly RegistryDevices _registry;
        private readonly NetworkSettings _settings;
        private readonly UdpEventResponse _responseProcessor;
        private readonly UdpHeartbeatService _heartbeatService;

        public UdpListener(
            ILogger<UdpListener> logger,
            RegistryDevices registry,
            IOptions<NetworkSettings> options,
            UdpEventResponse responseProcessor,
            UdpHeartbeatService heartbeatService)
        {
            _logger = logger;
            _registry = registry;
            _responseProcessor = responseProcessor;
            _heartbeatService = heartbeatService;
            _settings = RootSetting.Roots?.AppSettings?.NetworkSetting ?? options.Value ?? new NetworkSettings();
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            var listenPort = _settings.UdpListenPort;
            using var udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, listenPort));
            using var registration = stoppingToken.Register(() => udpClient.Dispose());

            _logger.LogInformation("UDP listener started on port {Port}", listenPort);

            while (!stoppingToken.IsCancellationRequested)
            {
                UdpReceiveResult result;
                try
                {
                    result = await udpClient.ReceiveAsync().ConfigureAwait(false);
                }
                catch (ObjectDisposedException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "UDP receive failed");
                    await Task.Delay(500, stoppingToken).ConfigureAwait(false);
                    continue;
                }

                var device = CreateOrRefreshDevice(result.RemoteEndPoint);
                _heartbeatService.EnsureHeartbeat(result.RemoteEndPoint);
                await _responseProcessor.ProcessAsync(device, result, stoppingToken).ConfigureAwait(false);
            }
        }

        private RegisteredDevices CreateOrRefreshDevice(IPEndPoint remote)
        {
            var address = remote.Address.ToString();
            if (!_registry.TryGet(address, out var existing) || existing is null)
            {
                var device = new RegisteredDevices(address, remote.Port, DateTimeOffset.UtcNow, "UDP", Array.Empty<byte>());
                _registry.TryPublish(device);
                return device;
            }

            var refreshed = new RegisteredDevices(existing.Address, remote.Port, DateTimeOffset.UtcNow, existing.Protocol, existing.LastPayload)
            {
                HeartbeatAcknowledged = existing.HeartbeatAcknowledged,
                HandshakeCompleted = existing.HandshakeCompleted,
                Stream = existing.Stream
            };

            _registry.TryUpdate(refreshed);
            return refreshed;
        }
    }
}
