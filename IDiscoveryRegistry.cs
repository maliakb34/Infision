using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace Infision;

public sealed class DiscoveredDevice
{
    public DiscoveredDevice(string address, int port, DateTimeOffset seenAtUtc, string protocol, byte[] lastPayload)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Port = port;
        SeenAtUtc = seenAtUtc;
        Protocol = protocol;
        LastPayload = lastPayload is { Length: > 0 } ? (byte[])lastPayload.Clone() : Array.Empty<byte>();
    }

    public static DiscoveredDevice From(IPAddress address, int port, DateTimeOffset seenAtUtc, string protocol, ReadOnlySpan<byte> payload)
        => new(address.ToString(), port, seenAtUtc, protocol, payload.ToArray());

    public string Address { get; init; } = string.Empty;
    public int Port { get; init; }
    public DateTimeOffset SeenAtUtc { get; init; }
    public string Protocol { get; init; } = string.Empty;
    public byte[] LastPayload { get; init; } = Array.Empty<byte>();

    public bool HeartbeatAcknowledged { get; set; }
    public bool HandshakeCompleted { get; set; }
    public NetworkStream? Stream { get; set; }
}

public interface IDiscoveryRegistry
{
    bool TryPublish(DiscoveredDevice dev);
<<<<<<< HEAD
    bool TryUpdate(DiscoveredDevice dev);
=======
    ValueTask PublishAsync(DiscoveredDevice dev, CancellationToken ct = default);
    DiscoveredDevice? TryUpdate(DiscoveredDevice dev);
>>>>>>> alarm dataları yapıldı
    bool TryRemove(string address, out DiscoveredDevice? removed);
    bool TryGet(string address, out DiscoveredDevice? device);
}

public sealed class DiscoveryRegistry : IDiscoveryRegistry
{
    private readonly ConcurrentDictionary<string, DiscoveredDevice> _devices = new();

    public DiscoveryRegistry()
    {
    }

    public bool TryPublish(DiscoveredDevice dev)
    {
        var key = Normalize(dev.Address);
        var added = _devices.TryAdd(key, dev);
<<<<<<< HEAD
        _devices[key] = dev; // snapshot güncel
        return added;
=======

        _devices[key] = dev; // keep freshest snapshot

        if (!added)
        {
            // already known device -> no new entry
            return true;
        }

        if (!ShouldEmit(key))
            return true;

        return _channel.Writer.TryWrite(dev);
    }

    public async ValueTask PublishAsync(DiscoveredDevice dev, CancellationToken ct = default)
    {
        var key = Normalize(dev.Address);
        var added = _devices.TryAdd(key, dev);

        _devices[key] = dev;

        if (!added)
        {
            return;
        }

        if (!ShouldEmit(key))
            return;

        await _channel.Writer.WriteAsync(dev, ct);
>>>>>>> alarm dataları yapıldı
    }

    public DiscoveredDevice? TryUpdate(DiscoveredDevice dev)
    {
        var key = Normalize(dev.Address);
        if (!_devices.ContainsKey(key))
            return null;

        _devices[key] = dev;
<<<<<<< HEAD
        return true;
=======
        _lastSeen[key] = DateTimeOffset.UtcNow;
        return dev;
>>>>>>> alarm dataları yapıldı
    }

    public bool TryRemove(string address, out DiscoveredDevice? removed)
    {
        var key = Normalize(address);
        return _devices.TryRemove(key, out removed);
    }

    public bool TryGet(string address, out DiscoveredDevice? device)
    {
        var key = Normalize(address);
        return _devices.TryGetValue(key, out device);
    }

<<<<<<< HEAD
=======
    private bool ShouldEmit(string key)
    {
        var now = DateTimeOffset.UtcNow;

        if (_lastSeen.TryGetValue(key, out var prev) && (now - prev) < _debounce)
            return false;

        _lastSeen[key] = now;
        return true;
    }

>>>>>>> alarm dataları yapıldı
    private static string Normalize(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            return string.Empty;

        var trimmed = address.Trim();

<<<<<<< HEAD
        if (TryNormalizeIpLiteral(trimmed, out var normalized))
            return normalized;
=======
        // If it's already a pure IP string
        if (IPAddress.TryParse(trimmed, out var ip))
            return ip.ToString();
>>>>>>> alarm dataları yapıldı

        // IPv6 with brackets e.g. [fe80::1%12]:9900
        if (trimmed.StartsWith("[", StringComparison.Ordinal))
        {
            int end = trimmed.IndexOf(']');
            if (end > 1)
            {
                var inner = trimmed.Substring(1, end - 1);
                if (TryNormalizeIpLiteral(inner, out normalized))
                    return normalized;
            }
        }

        // Try to split host:port (IPv4)
        int lastColon = trimmed.LastIndexOf(':');
        if (lastColon > 0)
        {
<<<<<<< HEAD
            var hostPart = trimmed[..lastColon];
            if (TryNormalizeIpLiteral(hostPart, out normalized))
                return normalized;
=======
            var hostPart = trimmed.Substring(0, lastColon);
            if (IPAddress.TryParse(hostPart, out ip))
                return ip.ToString();
>>>>>>> alarm dataları yapıldı
        }

        return trimmed;
    }
<<<<<<< HEAD

    private static bool TryNormalizeIpLiteral(string candidate, out string normalized)
    {
        if (IPAddress.TryParse(candidate, out var ip))
        {
            if (ip.AddressFamily == AddressFamily.InterNetworkV6 && ip.IsIPv4MappedToIPv6)
            {
                normalized = ip.MapToIPv4().ToString();
                return true;
            }

            normalized = ip.ToString();
            return true;
        }

        normalized = string.Empty;
        return false;
    }
=======
>>>>>>> alarm dataları yapıldı
}
