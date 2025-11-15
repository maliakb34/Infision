using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Infision.MHCP.UDP.Model;
using Infision.MHCP.UDP.Tools;
using Microsoft.Extensions.Logging;

namespace Infision.MHCP.UDP
{
    public sealed class UdpEventRequest
    {
        private readonly ILogger<UdpEventRequest> _logger;

        public UdpEventRequest(ILogger<UdpEventRequest> logger)
        {
            _logger = logger;
        }

        public async Task SendAsync(IPEndPoint endpoint, ReadOnlyMemory<byte> payload, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(endpoint);

            using var udpClient = new UdpClient();
            var buffer = payload.ToArray();

            try
            {
                await udpClient.SendAsync(buffer, buffer.Length, endpoint).ConfigureAwait(false);
                _logger.LogDebug("UDP packet sent to {Endpoint} ({Length} bytes)", endpoint, buffer.Length);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to send UDP payload to {Endpoint}", endpoint);
            }
        }

        public Task SendPatientInfoRequestAsync(string ipAddress, int port, CancellationToken ct = default)
        {
            if (!IPAddress.TryParse(ipAddress, out var ip))
                throw new ArgumentException("Invalid IP address", nameof(ipAddress));

            return SendPatientInfoRequestAsync(new IPEndPoint(ip, port), ct);
        }

        public Task SendPatientInfoRequestAsync(IPEndPoint endpoint, CancellationToken ct = default)
        {
            var payload = PacketBuilder.BuildPatientInfoRequest();
            return SendAsync(endpoint, payload, ct);
        }

        public Task SendPatientAsync(IPEndPoint endpoint, PatientStationInfo patient, int slotNumber, CancellationToken ct = default)
        {
            ArgumentNullException.ThrowIfNull(endpoint);
            ArgumentNullException.ThrowIfNull(patient);

            var payload = PacketBuilder.BuildCommandPacket(777, slotNumber, patient.ToCommandPayload());
            return SendAsync(endpoint, payload, ct);
        }

        public Task SendPatientAsync(string ipAddress, int port, PatientStationInfo patient, int slotNumber, CancellationToken ct = default)
        {
            if (!IPAddress.TryParse(ipAddress, out var ip))
                throw new ArgumentException("Invalid IP address", nameof(ipAddress));

            return SendPatientAsync(new IPEndPoint(ip, port), patient, slotNumber, ct);
        }
    }
}
