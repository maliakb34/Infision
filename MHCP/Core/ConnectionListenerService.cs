using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Infision.Configure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infision.MHCP
{
    public sealed class ConnectionListenerService : BackgroundService
    {
        private readonly ILogger<ConnectionListenerService> _logger;
        private readonly ConnectionManager _manager;
        private readonly IDiscoveryRegistry _registry;

        private TcpListener? _listener;
        private readonly NetworkSettings _opt;
        public ConnectionListenerService(
            ILogger<ConnectionListenerService> logger,
            ConnectionManager manager,
            IDiscoveryRegistry registry,
            IOptions<NetworkSettings> options)
        {
            _logger = logger;
            _manager = manager;
            _registry = registry;
            _opt = options.Value ?? new NetworkSettings();

            _opt = RootSetting.Roots.AppSettings.NetworkSetting;
            // Ensure `ServerIp` is parsed correctly if provided.

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var listenIp = IPAddress.Any;
            if (!string.IsNullOrWhiteSpace(_opt.ServerIp) &&
                IPAddress.TryParse(_opt.ServerIp, out var parsed))
            {
                listenIp = parsed;
            }

            var listenPort = _opt.TcpPort > 0 ? _opt.TcpPort : 9900;


            _listener = new TcpListener(listenIp, listenPort);
            //  _listener.Start();

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    TcpClient client;
                    try
                    {
                        client = await _listener.AcceptTcpClientAsync(stoppingToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }

                    _ = HandleClientAsync(client, listenPort, stoppingToken);
                }
            }
            finally
            {
                _listener.Stop();
            }
        }

        private async Task HandleClientAsync(TcpClient client, int listenPort, CancellationToken parentToken)
        {
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(parentToken);
            try
            {
                if (client.Client.RemoteEndPoint is not IPEndPoint remote)
                {
                    client.Dispose();
                    return;
                }

                var address = remote.Address.ToString();
                var device = CreateOrRefreshDevice(address, listenPort);

                await _manager.HandleAcceptedClientAsync(device, client, linkedCts.Token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to process incoming connection");
                client.Dispose();
            }
        }

        private DiscoveredDevice CreateOrRefreshDevice(string address, int port)
        {
            if (!_registry.TryGet(address, out var existing) || existing is null)
            {
                var device = new DiscoveredDevice(address, port, DateTimeOffset.UtcNow, "TCP", Array.Empty<byte>());
                _registry.TryPublish(device);
                return device;
            }
            else
            {
                var device = new DiscoveredDevice(address, port, DateTimeOffset.UtcNow, "TCP", existing.LastPayload)
                {
                    HeartbeatAcknowledged = false,
                    HandshakeCompleted = false
                };
                _registry.TryUpdate(device);
                return device;
            }
        }
    }
}