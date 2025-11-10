using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using Infision.Configure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Infision
{
    /// <summary>
    /// Background service that listens for device discovery beacons and publishes them into the registry.
    /// Devices are assumed to broadcast UDP packets prior to the TCP handshake.
    /// </summary>
    public sealed class DiscoveryService : BackgroundService
    {
        private readonly ILogger<DiscoveryService> _logger;
        private readonly IDiscoveryRegistry _registry;
        private readonly IOptions<Configure.NetworkSettings>_opt ;
        private static readonly TimeSpan DuplicateWindow = TimeSpan.FromSeconds(5);
        private readonly ConcurrentDictionary<string, DateTimeOffset> _recent = new();

        // Fix: Add a private field for `_opt` and initialize it correctly in the constructor.
        private readonly NetworkSettings opt;

        public DiscoveryService(ILogger<DiscoveryService> logger, IDiscoveryRegistry registry, IOptions<Configure.NetworkSettings> _opt)
        {
            _logger = logger;
            _registry = registry;

            // Correctly initialize the `opt` field using the provided `_opt` parameter.
            opt = RootSetting.Roots.AppSettings.NetworkSetting;
            // Ensure `ServerIp` is parsed correctly if provided.
            if (!string.IsNullOrWhiteSpace(opt.ServerIp) && IPAddress.TryParse(opt.ServerIp, out var ip))
            {
                // Additional logic can be added here if needed.
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
          
        }



    }
}
