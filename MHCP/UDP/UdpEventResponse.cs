using Infision;
using Infision.MHCP.UDP.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Buffers.Binary;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP.UDP
{
    public sealed class UdpEventResponse
    {
        private readonly ILogger<UdpEventResponse> _logger;
        private readonly PumpDataParser _pumpParser;
        private readonly PatientStationAnalyzer _patientAnalyzer;

        public UdpEventResponse(
            ILogger<UdpEventResponse> logger,
            PumpDataParser pumpParser,
            PatientStationAnalyzer patientAnalyzer)
        {
            _logger = logger;
            _pumpParser = pumpParser;
            _patientAnalyzer = patientAnalyzer;
        }

        public Task ProcessAsync(RegisteredDevices device, UdpReceiveResult result, CancellationToken ct = default)
        {
            var buffer = result.Buffer;
            if (buffer is null || buffer.Length < 4)
                return Task.CompletedTask;

            var cmd = ParseCommand(buffer);
            switch (cmd)
            {
                case 0x0360:
                    LogRealtime(device, buffer);

                    break;

                case 0x8306:
                    LogPatientInfo(device, buffer);
                    break;

                default:
                    _logger.LogDebug("UDP[{Device}] command 0x{Command:X4} ({Length} bytes)", device.Address, cmd, buffer.Length);
                    break;
            }

            return Task.CompletedTask;
        }

        private void LogRealtime(RegisteredDevices device, byte[] buffer)
        {
            try
            {
                PumpRealData realtime = _pumpParser.Parse(buffer);
                _logger.LogInformation("UDP[{Device}] realtime: {@Data}", device.Address, realtime);

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to parse realtime payload from {Device}", device.Address);
            }
        }

        private void LogPatientInfo(RegisteredDevices device, byte[] buffer)
        {
            try
            {
                PatientStationInfo patient = _patientAnalyzer.Parse(buffer);
                _logger.LogInformation("UDP[{Device}] patient info: {@Data}", device.Address, patient);








            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to parse patient info payload from {Device}", device.Address);
            }
        }

        private static ushort ParseCommand(byte[] buffer)
        {
            if (buffer.Length < 3)
                return 0;

            Span<byte> cmdBytes = stackalloc byte[2];
            cmdBytes[0] = buffer[1];
            cmdBytes[1] = buffer[2];
            return BinaryPrimitives.ReadUInt16LittleEndian(cmdBytes);
        }
    }
}
