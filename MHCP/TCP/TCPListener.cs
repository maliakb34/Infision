using Infision.Configure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP.TCP
{
    public sealed class TCPListener
    {
        private readonly ILogger<TCPListener> _logger;
        private readonly RegistryDevices _registry;
        private readonly NetworkSettings _networkSettings;
        private TcpListener? _listener;

        public TCPListener(ILogger<TCPListener> logger, RegistryDevices registry, IOptions<NetworkSettings> options)
        {
            _logger = logger;
            _registry = registry;
            _networkSettings = RootSetting.Roots?.AppSettings?.NetworkSetting ?? options.Value ?? new NetworkSettings();
        }

        public async Task ExecuteAsync(Func<RegisteredDevices, TcpClient, CancellationToken, Task> clientHandler, CancellationToken stoppingToken)
        {
            ArgumentNullException.ThrowIfNull(clientHandler);

            var listenIp = IPAddress.Any;
            if (!string.IsNullOrWhiteSpace(_networkSettings.ServerIp) &&
                IPAddress.TryParse(_networkSettings.ServerIp, out var parsed))
            {
                listenIp = parsed;
            }

            var listenPort = _networkSettings.TcpPort > 0 ? _networkSettings.TcpPort : 9900;

            _listener = new TcpListener(listenIp, listenPort);
            _listener.Start();

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var client = await _listener.AcceptTcpClientAsync(stoppingToken).ConfigureAwait(false);
                    _ = AcceptClient(client, listenPort, clientHandler, stoppingToken);
                }
            }
            finally
            {
                _listener.Stop();
            }
        }

        private async Task AcceptClient(
            TcpClient client,
            int listenPort,
            Func<RegisteredDevices, TcpClient, CancellationToken, Task> clientHandler,
            CancellationToken parentToken)
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

                await clientHandler(device, client, linkedCts.Token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to process incoming connection");
                client.Dispose();
            }
        }

        public RegisteredDevices CreateOrRefreshDevice(string address, int port)
        {
            if (!_registry.TryGet(address, out var existing) || existing is null)
            {
                var device = new RegisteredDevices(address, port, DateTimeOffset.UtcNow, "TCP", Array.Empty<byte>());
                _registry.TryPublish(device);
                return device;
            }

            var refreshed = new RegisteredDevices(existing.Address, existing.Port, DateTimeOffset.UtcNow, existing.Protocol, existing.LastPayload)
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
