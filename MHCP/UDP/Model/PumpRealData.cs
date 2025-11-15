namespace Infision.MHCP.UDP.Model
{
    public sealed class PumpRealData
    {
        public string Serial { get; init; } = string.Empty;
        public byte DeviceType { get; init; }
        public string Model { get; init; } = string.Empty;
        public string Workstation { get; init; } = string.Empty;
        public string Department { get; init; } = string.Empty;
        public string Room { get; init; } = string.Empty;
        public string Bed { get; init; } = string.Empty;
        public byte State { get; init; }
        public string Drug { get; init; } = string.Empty;
        public byte Mode { get; init; }
        public float Vtbi { get; init; }
        public float Rate { get; init; }
        public uint InfusedTime { get; init; }
        public uint RemainingTime { get; init; }
        public float Infused { get; init; }
        public float Remaining { get; init; }
        public uint Alarm { get; init; }
    }
}
