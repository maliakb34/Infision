using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Infision.MHCP
{
    public static class MhcpWire
    {
        private static int _seq;
        public static int NextSeq() => Interlocked.Increment(ref _seq);

        public static byte[] Build(byte[] header, byte[] payload)
        {
            var sync = new byte[] { 0xFA, 0x05 };
            ushort headerLen = (ushort)header.Length;
            ushort totalLen = (ushort)(sync.Length + 2 + 2 + 2 + header.Length + payload.Length);

            var tail = new List<byte>(2 + 2 + header.Length + payload.Length);
            WriteUInt16LE(tail, totalLen);     // TOTAL_LEN
            WriteUInt16LE(tail, headerLen);    // HEADER_LEN
            tail.AddRange(header);
            tail.AddRange(payload);

            ushort crc = MhcpCrc16.Compute(tail.ToArray()); // CRC over [TOTAL_LEN..end]

            var frame = new List<byte>(totalLen);
            frame.AddRange(sync);
            WriteUInt16LE(frame, crc);
            frame.AddRange(tail);
            return frame.ToArray();
        }

        private static void WriteUInt16LE(List<byte> b, ushort v)
        {
            b.Add((byte)(v & 0xFF));
            b.Add((byte)((v >> 8) & 0xFF));
        }

        public static async Task<(byte[] Header, byte[] Payload)> ReadFrameAsync(NetworkStream stream, CancellationToken ct = default)
        {
            // SYNC(2)
            int state = 0;
            while (true)
            {
                int b = stream.ReadByte();
                if (b == -1) throw new EndOfStreamException();
                if (state == 0 && b == 0xFA) { state = 1; continue; }
                if (state == 1 && b == 0x05) break;
                state = 0;
            }

            // CRC(2) + TOTAL_LEN(2) + HEADER_LEN(2)
            var hdr = await ReadExactAsync(stream, 6, ct).ConfigureAwait(false);
            ushort recvCrc   = (ushort)(hdr[0] | (hdr[1] << 8));
            ushort totalLen  = (ushort)(hdr[2] | (hdr[3] << 8));
            ushort headerLen = (ushort)(hdr[4] | (hdr[5] << 8));

            if (totalLen < 8 || headerLen > totalLen - 8)
                throw new InvalidDataException("Invalid MHCP lengths");

            int restLen = totalLen - 8;
            byte[] rest = ArrayPool<byte>.Shared.Rent(restLen);
            try
            {
                await ReadExactAsync(stream, rest.AsMemory(0, restLen), ct).ConfigureAwait(false);

                // CRC validation over [TOTAL_LEN..end] => hdr[2..5] + rest
                var crcBuf = new byte[4 + restLen];
                Buffer.BlockCopy(hdr, 2, crcBuf, 0, 4);
                Buffer.BlockCopy(rest, 0, crcBuf, 4, restLen);
                if (MhcpCrc16.Compute(crcBuf) != recvCrc)
                    throw new InvalidDataException("MHCP CRC mismatch");

                // Split header/payload
                var headerBytes = new byte[headerLen];
                Buffer.BlockCopy(rest, 0, headerBytes, 0, headerLen);
                int payloadLen = restLen - headerLen;
                var payloadBytes = payloadLen > 0 ? new byte[payloadLen] : Array.Empty<byte>();
                if (payloadLen > 0)
                    Buffer.BlockCopy(rest, headerLen, payloadBytes, 0, payloadLen);

                return (headerBytes, payloadBytes);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(rest);
            }
        }

        private static async Task<byte[]> ReadExactAsync(NetworkStream s, int len, CancellationToken ct)
        {
            var buf = new byte[len];
            await ReadExactAsync(s, buf.AsMemory(0, len), ct).ConfigureAwait(false);
            return buf;
        }

        private static async Task ReadExactAsync(NetworkStream s, Memory<byte> buf, CancellationToken ct)
        {
            int read = 0;
            while (read < buf.Length)
            {
                int n = await s.ReadAsync(buf.Slice(read), ct).ConfigureAwait(false);
                if (n <= 0) throw new EndOfStreamException();
                read += n;
            }
        }
    }
}

