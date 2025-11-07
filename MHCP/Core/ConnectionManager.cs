<<<<<<< HEAD
﻿using Infision.MHCP.Core;
=======
>>>>>>> alarm dataları yapıldı
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Infision.MHCP
{
    public sealed class ConnectionManager
    {
        private readonly IDiscoveryRegistry _registry;
        private readonly EventRequest _requestSender;
        private readonly EventResponse _responseProcessor;
        private readonly SemaphoreSlim _connectionLimiter;
        private readonly ConcurrentDictionary<string, ConnectionContext> _connections = new();
        private readonly TimeSpan _handshakeTimeout;
        private readonly ILogger<ConnectionManager>? _logger;

        public ConnectionManager(IDiscoveryRegistry registry,
                                 EventRequest requestSender,
                                 EventResponse responseProcessor,
                                 ILogger<ConnectionManager>? logger = null,
                                 int maxConnections = 100,
                                 TimeSpan? handshakeTimeout = null)
        {
            _registry = registry;
            _requestSender = requestSender;
            _responseProcessor = responseProcessor;
            _connectionLimiter = new SemaphoreSlim(maxConnections, maxConnections);
            _handshakeTimeout = handshakeTimeout ?? TimeSpan.FromSeconds(30);
            _logger = logger;
        }

        public Task RunAsync(CancellationToken ct = default)
        {
            return Task.Run(async () =>
            {
                await foreach (var device in _registry.Reader.ReadAllAsync(ct).ConfigureAwait(false))
                {
                    _logger?.LogDebug("Discovered device {Address} (protocol={Protocol}) enqueued", device.Address, device.Protocol);
                    // For inbound connections we just log discoveries; ConnectionListenerService handles actual sockets.
                }
            }, ct);
        }

        public async Task HandleAcceptedClientAsync(DiscoveredDevice device, TcpClient client, CancellationToken parentToken)
        {
            await _connectionLimiter.WaitAsync(parentToken).ConfigureAwait(false);
            try
            {
                await HandleTcpDeviceAsync(device, parentToken, client).ConfigureAwait(false);
            }
            finally
            {
                _connectionLimiter.Release();
            }
        }

        private async Task HandleTcpDeviceAsync(DiscoveredDevice device, CancellationToken parentToken, TcpClient? existingClient = null)
        {
            var address = device.Address;
            bool shouldCleanup = false;
            var client = existingClient ?? new TcpClient();

         
                if (device.HandshakeCompleted)
                    return;

                if (existingClient is null)
                {
                    if (!IPAddress.TryParse(address, out var ip))
                        throw new InvalidOperationException($"Invalid device IP: {address}");

                    using var connectCts = CancellationTokenSource.CreateLinkedTokenSource(parentToken);
                    await client.ConnectAsync(ip, device.Port, connectCts.Token).ConfigureAwait(false);
                }

                var stream = client.GetStream();
                device.Stream = stream;
                device.HeartbeatAcknowledged = false;
                device.HandshakeCompleted = false;
                device = _registry.TryUpdate(device) ?? device;

                var responseCts = CancellationTokenSource.CreateLinkedTokenSource(parentToken);
                var responseTask = _responseProcessor.RunAsync(device, stream, responseCts.Token);
                var context = new ConnectionContext(client, stream, responseCts, responseTask);
                if (!_connections.TryAdd(address, context))
                {
                    await context.DisposeAsync().ConfigureAwait(false);
                    return;
                }
                shouldCleanup = true;
<<<<<<< HEAD
                //BURAYA BİRDEN FAZLA KEZ GİRMESSİNE BAKILACAK//
=======

>>>>>>> alarm dataları yapıldı
                _responseProcessor.BeginHandshakeTracking(address);

                await _requestSender.SendAsync(stream, MhcpConstants.REQ_HEART_FREQ_SET, parentToken).ConfigureAwait(false);
                await _responseProcessor.WaitForHeartbeatAsync(address, _handshakeTimeout, parentToken).ConfigureAwait(false);
<<<<<<< HEAD
        
             
         
                await _requestSender.SendAsync(stream, MhcpConstants.REQ_PERIODIC_INFUSION_INTERVAL, parentToken).ConfigureAwait(false);
=======

                await _requestSender.SendAsync(stream, MhcpConstants.REQ_DEVICE_INFO, parentToken).ConfigureAwait(false);
                await _responseProcessor.WaitForDeviceInfoAsync(address, _handshakeTimeout, parentToken).ConfigureAwait(false);
>>>>>>> alarm dataları yapıldı

                if(device.HandshakeCompleted)
                {
                    await _requestSender.SendAsync(stream, MhcpConstants.REQ_PERIODIC_INFUSION_INTERVAL, parentToken).ConfigureAwait(false);

<<<<<<< HEAD
            await _requestSender.SendAsync(stream, MhcpConstants.REQ_DEVICE_INFO, parentToken).ConfigureAwait(false);
            await _responseProcessor.WaitForDeviceInfoAsync(address, _handshakeTimeout, parentToken).ConfigureAwait(false);


            await responseTask.ConfigureAwait(false);
            
     
         
=======
                    await _requestSender.SendAsync(stream, MhcpConstants.REQ_ALARM_INFO, parentToken).ConfigureAwait(false);
                }
            
                await responseTask.ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: add logging hook if required
            }
            finally
            {
                if (shouldCleanup)
                {
                    _responseProcessor.EndHandshakeTracking(address);
                    await CleanupAsync(address).ConfigureAwait(false);
                }
            }
>>>>>>> alarm dataları yapıldı
        }

        private async Task CleanupAsync(string address)
        {
            if (_connections.TryRemove(address, out var ctx))
            {
                await ctx.DisposeAsync().ConfigureAwait(false);
            }

            _registry.TryRemove(address, out _);
        }

        private sealed class ConnectionContext : IAsyncDisposable
        {
            private readonly TcpClient _client;
            private readonly NetworkStream _stream;
            private readonly CancellationTokenSource _responseCts;
            private readonly Task _responseTask;

            public ConnectionContext(TcpClient client, NetworkStream stream, CancellationTokenSource responseCts, Task responseTask)
            {
                _client = client;
                _stream = stream;
                _responseCts = responseCts;
                _responseTask = responseTask;
            }

            public async ValueTask DisposeAsync()
            {
                try
                {
                    _responseCts.Cancel();
                }
                catch { }

                try
                {
                    await _responseTask.ConfigureAwait(false);
                }
                catch { }

                _stream.Dispose();
                _client.Dispose();
                _responseCts.Dispose();
            }
        }
    }
}
