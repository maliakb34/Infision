// DiscoveryService.cs — PASİF SNIFFER (UDP/26800, NO SEND, NO BIND)
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Infision
{
    public sealed class DiscoveryService : BackgroundService
    {
        private readonly ILogger<DiscoveryService> _log;

        private readonly IDiscoveryRegistry _registry;

        public DiscoveryService(
            ILogger<DiscoveryService> log,
            IHubContext<MyHub> hub,
            IOptions<Configure.NetworkSettings> opt,
            IDiscoveryRegistry registry)
        {
            _log = log; _registry = registry;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {



       

            return Task.CompletedTask;
        }



   
    }
}
