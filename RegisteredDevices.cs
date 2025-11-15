using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace Infision;

/// <summary>
/// * Cihazların kayıt işlemlerini yürütür.
/// </summary>
public sealed class RegisteredDevices
{
    public RegisteredDevices(string address, int port, DateTimeOffset seenAtUtc, string protocol, byte[] lastPayload)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Port = port;
        SeenAtUtc = seenAtUtc;
        Protocol = protocol;
        LastPayload = lastPayload is { Length: > 0 } ? (byte[])lastPayload.Clone() : Array.Empty<byte>();
    }

    public static RegisteredDevices From(IPAddress address, int port, DateTimeOffset seenAtUtc, string protocol, ReadOnlySpan<byte> payload)
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

public sealed class RegistryDevices
{
    private readonly ConcurrentDictionary<string, RegisteredDevices> _devices = new();

    public RegistryDevices()
    {
    }

    public bool TryPublish(RegisteredDevices dev)
    {
        var key = Normalize(dev.Address);
        var added = _devices.TryAdd(key, dev);
        _devices[key] = dev; // snapshot güncel
        return added;
    }

    public bool TryUpdate(RegisteredDevices dev)
    {
        var key = Normalize(dev.Address);
        if (!_devices.ContainsKey(key))
            return false;

        _devices[key] = dev;
        return true;
    }

    public bool TryRemove(string address, out RegisteredDevices? removed)
    {
        var key = Normalize(address);
        return _devices.TryRemove(key, out removed);
    }

    public bool TryGet(string address, out RegisteredDevices? device)
    {
        var key = Normalize(address);
        return _devices.TryGetValue(key, out device);
    }

    private static string Normalize(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
            return string.Empty;

        var trimmed = address.Trim();

        if (TryNormalizeIpLiteral(trimmed, out var normalized))
            return normalized;

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

        int lastColon = trimmed.LastIndexOf(':');
        if (lastColon > 0)
        {
            var hostPart = trimmed[..lastColon];
            if (TryNormalizeIpLiteral(hostPart, out normalized))
                return normalized;
        }

        return trimmed;
    }

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
}
