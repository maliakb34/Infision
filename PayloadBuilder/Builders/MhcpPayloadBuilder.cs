using System;
using System.Threading;
using Infision.PayloadBuilder.Models;
using Infision.PayloadBuilder.Util;

namespace Infision.PayloadBuilder.Builders
{
    public class MhcpPayloadBuilder
    {
        const byte SyncFirst = 0xFA;
        const byte SyncSecond = 0x05;
        const int CategoryRequestResponse = 2;

        int _sequence;

        public MhcpPayloadBuilder(int initialSequence = 0)
        {
            _sequence = initialSequence;
        }

        public byte[] BuildPatientUpdate(Patient patient, int? sequenceOverride = null)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            var payload = BuildPatientInfo(patient);
            var sequence = sequenceOverride ?? NextSequence();
            var header = BuildHeader(messageId: 4100, categoryId: CategoryRequestResponse, requestResponse: RequestResponseType.Request, routeId: 0, sequenceNumber: sequence);
            return ComposeFrame(header, payload);
        }

        byte[] BuildHeader(int messageId, int categoryId, RequestResponseType requestResponse, int routeId, int sequenceNumber)
        {
            using var writer = new ProtoWriter();
            writer.WriteFieldVarint(1, (ulong)messageId);
            writer.WriteFieldVarint(2, (ulong)categoryId);
            writer.WriteFieldVarint(3, (ulong)sequenceNumber);
            if (routeId != 0)
            {
                writer.WriteFieldVarint(4, (ulong)routeId);
            }
            writer.WriteFieldVarint(5, (ulong)requestResponse);
            return writer.ToArray();
        }

        byte[] BuildPatientInfo(Patient patient)
        {
            using var writer = new ProtoWriter();

            if (!string.IsNullOrWhiteSpace(patient.Department))
                writer.WriteFieldString(2, patient.Department);
            if (!string.IsNullOrWhiteSpace(patient.Bed))
                writer.WriteFieldString(3, patient.Bed);
            if (!string.IsNullOrWhiteSpace(patient.Pid))
                writer.WriteFieldString(4, patient.Pid);
            if (!string.IsNullOrWhiteSpace(patient.VisitId))
                writer.WriteFieldString(5, patient.VisitId);
            if (!string.IsNullOrWhiteSpace(patient.LastName))
                writer.WriteFieldString(6, patient.LastName);
            if (!string.IsNullOrWhiteSpace(patient.FirstName))
                writer.WriteFieldString(7, patient.FirstName);
            if (patient.Gender != Infision.PayloadBuilder.Models.Gender.Unknown)
                writer.WriteFieldVarint(8, (ulong)patient.Gender);
            if (patient.Age.HasValue)
                writer.WriteFieldVarint(9, (ulong)Math.Max(0, patient.Age.Value));
            if (patient.AgeUnit != Infision.PayloadBuilder.Models.AgeUnit.Unknown)
                writer.WriteFieldVarint(10, (ulong)patient.AgeUnit);
            if (patient.HeightCm.HasValue)
            {
                var height = (float)Math.Round(patient.HeightCm.Value, 1, MidpointRounding.AwayFromZero);
                writer.WriteFieldFloat32(11, height);
            }
            if (patient.WeightKg.HasValue)
            {
                var weight = (float)Math.Round(patient.WeightKg.Value, 2, MidpointRounding.AwayFromZero);
                writer.WriteFieldFloat32(12, weight);
            }
            if (patient.BloodType != Infision.PayloadBuilder.Models.BloodType.Unknown)
                writer.WriteFieldVarint(13, (ulong)patient.BloodType);
            if (!string.IsNullOrWhiteSpace(patient.Physician))
                writer.WriteFieldString(14, patient.Physician);
            if (!string.IsNullOrWhiteSpace(patient.Diagnosis))
                writer.WriteFieldString(15, patient.Diagnosis);
            if (patient.AdmitDateUtc.HasValue)
            {
                var utc = DateTime.SpecifyKind(patient.AdmitDateUtc.Value, DateTimeKind.Utc);
                var milliseconds = new DateTimeOffset(utc).ToUnixTimeMilliseconds();
                writer.WriteFieldFixed64(16, (ulong)milliseconds);
            }

            return writer.ToArray();
        }

        byte[] ComposeFrame(byte[] header, byte[] payload)
        {
            short headerLength = (short)header.Length;
            short totalLength = (short)(payload.Length + headerLength + 8);

            var totalLenBytes = ToLittleEndian(totalLength);
            var headerLenBytes = ToLittleEndian(headerLength);

            var crcData = new byte[totalLenBytes.Length + headerLenBytes.Length + header.Length + payload.Length];
            Buffer.BlockCopy(totalLenBytes, 0, crcData, 0, totalLenBytes.Length);
            Buffer.BlockCopy(headerLenBytes, 0, crcData, totalLenBytes.Length, headerLenBytes.Length);
            Buffer.BlockCopy(header, 0, crcData, totalLenBytes.Length + headerLenBytes.Length, header.Length);
            Buffer.BlockCopy(payload, 0, crcData, totalLenBytes.Length + headerLenBytes.Length + header.Length, payload.Length);

            ushort crc = Crc16.ComputeCcitt(crcData);
            var crcBytes = ToLittleEndian((short)crc);

            var frame = new byte[2 + crcBytes.Length + crcData.Length];
            frame[0] = SyncFirst;
            frame[1] = SyncSecond;
            Buffer.BlockCopy(crcBytes, 0, frame, 2, crcBytes.Length);
            Buffer.BlockCopy(crcData, 0, frame, 2 + crcBytes.Length, crcData.Length);
            return frame;
        }

        static byte[] ToLittleEndian(short value)
        {
            var bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }

        int NextSequence()
        {
            var next = Interlocked.Increment(ref _sequence);
            if (next > ushort.MaxValue)
            {
                Interlocked.Exchange(ref _sequence, 0);
                next = Interlocked.Increment(ref _sequence);
            }
            return next;
        }

        enum RequestResponseType
        {
            None = 0,
            Request = 1,
            Response = 2
        }
    }
}
