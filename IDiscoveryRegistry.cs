using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Channels;

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
    ValueTask PublishAsync(DiscoveredDevice dev, CancellationToken ct = default);
    bool TryUpdate(DiscoveredDevice dev);
    bool TryRemove(string address, out DiscoveredDevice? removed);
    bool TryGet(string address, out DiscoveredDevice? device);
    ChannelReader<DiscoveredDevice> Reader { get; }
}

public sealed class DiscoveryRegistry : IDiscoveryRegistry
{
    private readonly Channel<DiscoveredDevice> _channel;
    private readonly ConcurrentDictionary<string, DateTimeOffset> _lastSeen = new();
    private readonly ConcurrentDictionary<string, DiscoveredDevice> _devices = new();
    private readonly TimeSpan _debounce = TimeSpan.FromSeconds(5);

    public DiscoveryRegistry(int capacity = 1024, BoundedChannelFullMode mode = BoundedChannelFullMode.Wait)
    {
        _channel = Channel.CreateBounded<DiscoveredDevice>(new BoundedChannelOptions(capacity)
        {
            SingleWriter = false,
            SingleReader = false,
            FullMode = mode
        });
    }

    public ChannelReader<DiscoveredDevice> Reader => _channel.Reader;

    public bool TryPublish(DiscoveredDevice dev)
    {
        var key = Normalize(dev.Address);
        var added = _devices.TryAdd(key, dev);

        _devices[key] = dev; // snapshot güncel

        if (!added)
        {
            // Aynı IP zaten kayıtlıysa kuyrukta tekrarına gerek yok
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

        if (!added || !ShouldEmit(key))
            return;

        await _channel.Writer.WriteAsync(dev, ct);
    }

    public bool TryUpdate(DiscoveredDevice dev)
    {
        var key = Normalize(dev.Address);
        if (!_devices.ContainsKey(key))
            return false;

        _devices[key] = dev;
        _lastSeen[key] = DateTimeOffset.UtcNow;
        return true;
    }

    public bool TryRemove(string address, out DiscoveredDevice? removed)
    {
        var key = Normalize(address);
        var result = _devices.TryRemove(key, out removed);
        if (result)
        {
            _lastSeen.TryRemove(key, out _);
        }
        return result;
    }

    public bool TryGet(string address, out DiscoveredDevice? device)
    {
        var key = Normalize(address);
        return _devices.TryGetValue(key, out device);
    }

    private bool ShouldEmit(string key)
    {
        var now = DateTimeOffset.UtcNow;
        if (_lastSeen.TryGetValue(key, out var prev) && (now - prev) < _debounce)
            return false;

        _lastSeen[key] = now;
        return true;
    }

    private static string Normalize(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            return string.Empty;

        var trimmed = address.Trim();

        if (IPAddress.TryParse(trimmed, out var ip))
            return ip.ToString();

        if (trimmed.StartsWith("[", StringComparison.Ordinal))
        {
            int end = trimmed.IndexOf(']');
            if (end > 1)
            {
                var inner = trimmed.Substring(1, end - 1);
                if (IPAddress.TryParse(inner, out ip))
                    return ip.ToString();
            }
        }

        int lastColon = trimmed.LastIndexOf(':');
        if (lastColon > 0)
        {
            var hostPart = trimmed[..lastColon];
            if (IPAddress.TryParse(hostPart, out ip))
                return ip.ToString();
        }

        return trimmed;
    }
}