using System.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace Infision.MHCP
{
    /// <summary>
    /// Shared context passed to MHCP message handlers.
    /// </summary>
    public sealed class MhcpMessageContext
    {
        public MhcpMessageContext(DiscoveredDevice device, NetworkStream stream, ILogger? logger = null)
        {
            Device = device;
            Stream = stream;
            Logger = logger;
        }

        public DiscoveredDevice Device { get; }

        public NetworkStream Stream { get; }

        public ILogger? Logger { get; }
    }
}

