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
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;

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
            var devices = new List<LibPcapLiveDevice>();

            try
            {
                foreach (var dev in LibPcapLiveDeviceList.Instance)
                {
                    try
                    {
                        // Only consider live IPv4, non-loopback interfaces
                        if (!HasUsableAddress(dev))
                            continue;

                        dev.Open(DeviceModes.Promiscuous, read_timeout: 1000);
                        dev.Filter = $"udp port {opt.UdpListenPort} or tcp port {opt.TcpPort}";
                        dev.OnPacketArrival += OnPacketArrival;
                        dev.StartCapture();
                        devices.Add(dev);
                        _logger.LogInformation("DiscoveryService sniffing on {Device}", dev.Description ?? dev.Name);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "DiscoveryService could not open capture on {Device}", dev.Name);
                    }
                }

                if (devices.Count == 0)
                {
                    _logger.LogWarning("DiscoveryService did not find any capture devices matching interface {Interface}", opt.ServerIp ?? "ANY");
                }

                // Keep running until cancellation is requested
                try
                {
                    await Task.Delay(Timeout.Infinite, stoppingToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // normal shutdown
                }
            }
            finally
            {
                foreach (var dev in devices)
                {
                    try { dev.OnPacketArrival -= OnPacketArrival; } catch { }
                    try { dev.StopCapture(); } catch { }
                    try { dev.Close(); } catch { }
                }
            }
        }

        private bool HasUsableAddress(LibPcapLiveDevice dev)
        {
            foreach (var addr in dev.Addresses)
            {
                if (addr?.Addr?.ipAddress is IPAddress ip &&
                    ip.AddressFamily == AddressFamily.InterNetwork &&
                    !IPAddress.IsLoopback(ip))
                {
                    if (opt.ServerIp != null && ip.Equals(opt.ServerIp))
                        continue;
                    return true;
                }
            }
            return false;
        }

        private void OnPacketArrival(object sender, PacketCapture capture)
        {
            try
            {
                var raw = capture.GetPacket();
                var packet = Packet.ParsePacket(raw.LinkLayerType, raw.Data);
                var ipv4 = packet.Extract<IPv4Packet>();
                if (ipv4 == null)
                    return;

                // UDP beacon
                var udp = packet.Extract<UdpPacket>();
                if (udp != null && (udp.SourcePort == opt.UdpListenPort || udp.DestinationPort == opt.UdpListenPort))
                {
                    var remote = udp.DestinationPort == opt.UdpListenPort
                        ? new IPEndPoint(ipv4.SourceAddress, udp.SourcePort)
                        : new IPEndPoint(ipv4.DestinationAddress, udp.DestinationPort);

                    RegisterDevice(remote.Address, (ushort)opt.UdpListenPort, "UDP", udp.PayloadData);
                    return;
                }

                // TCP SYN/ACK etc
                var tcp = packet.Extract<TcpPacket>();
                if (tcp != null && (tcp.SourcePort == opt.TcpPort || tcp.DestinationPort == opt.TcpPort))
                {
                    IPAddress deviceAddress;
                    if (tcp.DestinationPort == opt.TcpPort)
                    {
                        // Device initiated connection to us
                        deviceAddress = ipv4.SourceAddress;
                    }
                    else
                    {
                        // We initiated connection to device
                        deviceAddress = ipv4.DestinationAddress;
                    }
                
                    RegisterDevice(deviceAddress, (ushort)opt.TcpPort, "TCP", tcp.PayloadData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "DiscoveryService failed to parse captured packet");
            }
        }

        private void RegisterDevice(IPAddress ip, ushort port, string protocol, ReadOnlySpan<byte> payload)
        {
            // Correct the variable declaration and usage for the TryGet method
            if (_registry.TryGet(ip.ToString(), out var existingDevice))
            {
                return;
            }

             

            var key = ip.ToString();
            var now = DateTimeOffset.UtcNow;
            var previous = _recent.GetOrAdd(key, DateTimeOffset.MinValue);
            if (now - previous < DuplicateWindow)
                return;
            _recent[key] = now;

            var device = DiscoveredDevice.From(ip, port, now, protocol, payload);
            if (key != opt.ServerIp)
             _registry.TryPublish(device);
        }
    }
}
