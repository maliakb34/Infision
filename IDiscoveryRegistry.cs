// DiscoveryRegistry.cs
using System.Collections.Concurrent;
using System.Net;
using System.Threading.Channels;

namespace Infision;

public sealed class DiscoveredDevice
{
    // JSON-dostu ctor (address string)
    public DiscoveredDevice(string address, int port, DateTimeOffset seenAtUtc, byte[] lastPayload)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Port = port;
        SeenAtUtc = seenAtUtc;
        LastPayload = (lastPayload is { Length: > 0 }) ? (byte[])lastPayload.Clone() : Array.Empty<byte>();
    }

    // Kolaylık: IPAddress’ten üret (UDP tarafında bunu çağırabilirsin)
    public static DiscoveredDevice From(IPAddress address, int port, DateTimeOffset seenAtUtc, ReadOnlySpan<byte> payload)
        => new DiscoveredDevice(address.ToString(), port, seenAtUtc, payload.ToArray());

    // JSON'da sorunsuz alanlar
    public string Address { get; init; } = string.Empty;   // <- artık string
    public int Port { get; init; }
    public DateTimeOffset SeenAtUtc { get; init; }         // istersen ileride epoch(ms) long'a çevirebiliriz
    public byte[] LastPayload { get; init; } = Array.Empty<byte>(); // JSON'da Base64 olur
}

public interface IDiscoveryRegistry
{
    bool TryPublish(DiscoveredDevice dev);
    ValueTask PublishAsync(DiscoveredDevice dev, CancellationToken ct = default);
    ChannelReader<DiscoveredDevice> Reader { get; }
}

public sealed class DiscoveryRegistry : IDiscoveryRegistry
{
    private readonly Channel<DiscoveredDevice> _ch;
    private readonly ConcurrentDictionary<string, DateTimeOffset> _lastSeen = new();
    private readonly TimeSpan _debounce = TimeSpan.FromSeconds(5);

    public DiscoveryRegistry(int capacity = 1024, BoundedChannelFullMode mode = BoundedChannelFullMode.Wait)
    {
        _ch = Channel.CreateBounded<DiscoveredDevice>(new BoundedChannelOptions(capacity)
        {
            SingleWriter = false,
            SingleReader = false,
            FullMode = mode
        });
    }

    public ChannelReader<DiscoveredDevice> Reader => _ch.Reader;

    public bool TryPublish(DiscoveredDevice dev)
    {
        if (!ShouldEmit(dev)) return true; // sessizce yut (debounce)
        return _ch.Writer.TryWrite(dev);
    }

    public async ValueTask PublishAsync(DiscoveredDevice dev, CancellationToken ct = default)
    {
        if (!ShouldEmit(dev)) return;
        await _ch.Writer.WriteAsync(dev, ct);
    }

    private bool ShouldEmit(DiscoveredDevice dev)
    {
        var key = $"{dev.Address}:{dev.Port}"; // string address ile çalışır
        var now = DateTimeOffset.UtcNow;

        if (_lastSeen.TryGetValue(key, out var prev) && (now - prev) < _debounce)
            return false;

        _lastSeen[key] = now;
        return true;
    }
}
