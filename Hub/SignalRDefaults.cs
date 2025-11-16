namespace Infision.HubConfig
{
    /// <summary>
    /// Shared SignalR constants so producer/consumer pick the same routing keys.
    /// </summary>
    public static class SignalRDefaults
    {
        /// <summary>
        /// Users whose `signalrid` equals this key will receive raw UDP telemetry messages.
        /// </summary>
        public const string UdpRealtimeKey = "mhcp-udp-realtime-v1";
    }
}
