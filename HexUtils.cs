using System;

/// <summary>
/// Utility methods for converting between byte arrays and hex strings.
/// </summary>
namespace Infision
{
    public static class HexUtils
    {
        /// <summary>
        /// Parse a hexadecimal string into a byte array. Whitespace and hyphens
        /// are ignored. Supports optional "0x" prefix.
        /// </summary>
        public static byte[] FromHexString(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex)) return Array.Empty<byte>();
            hex = hex.Trim();
            if (hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) hex = hex.Substring(2);
            hex = hex.Replace(" ", string.Empty).Replace("-", string.Empty);
            int len = hex.Length;
            if (len % 2 != 0) throw new FormatException("Hex string length must be even");
            byte[] bytes = new byte[len / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                string pair = hex.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(pair, 16);
            }
            return bytes;
        }

        /// <summary>
        /// Convert a byte array to a hex string with no separators.
        /// </summary>
        public static string ToHexString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLowerInvariant();
        }
    }
}