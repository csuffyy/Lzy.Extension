using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lzy.Extension
{
    /// <summary>
    /// Byte类型的扩展方法
    /// </summary>
    public static class ByteExtension
    {
        #region ToHex

        /// <summary>
        /// To the hexadecimal.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns>System.String.</returns>
        public static string ToHex(this byte b)
        {
            return b.ToString("X2");
        }

        /// <summary>
        /// To the hexadecimal.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string ToHex(this byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// To the hexadecimal.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string ToHex(this IEnumerable<byte> bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// To the hexadecimal with separator.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="c">The c.</param>
        /// <returns>System.String.</returns>
        public static string ToHexWithSeparator(this byte[] bytes, char c)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(c);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// To the hexadecimal with separator.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="c">The c.</param>
        /// <returns>System.String.</returns>
        public static string ToHexWithSeparator(this IEnumerable<byte> bytes, char c)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(c);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// To the hexadecimal with separator.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        public static string ToHexWithSeparator(this byte[] bytes, string separator)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(separator);
            }
            sb.Remove(sb.Length - separator.Length, separator.Length);
            return sb.ToString();
        }

        /// <summary>
        /// To the hexadecimal with separator.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        public static string ToHexWithSeparator(this IEnumerable<byte> bytes, string separator)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(separator);
            }
            sb.Remove(sb.Length - separator.Length, separator.Length);
            return sb.ToString();
        }

        /// <summary>
        /// To the int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt32(this byte[] value, int startIndex)
        {
            return BitConverter.ToInt32(value, startIndex);
        }

        /// <summary>
        /// To the int64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.Int64.</returns>
        public static long ToInt64(this byte[] value, int startIndex)
        {
            return BitConverter.ToInt64(value, startIndex);
        }

        #endregion
        
        #region 位操作

        /// <summary>
        /// 获取第index是否为1 (index从0开始)
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool GetBit(this byte b, int index)
        {
            return (b & (1 << index)) > 0;
        }

        /// <summary>
        /// 将第index位设为1
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte SetBit(this byte b, int index)
        {
            b |= (byte)(1 << index);
            return b;
        }

        /// <summary>
        /// 将第index位设为0 (从低位开始)
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte ResetBit(this byte b, int index)
        {
            b &= (byte)((1 << 8) - 1 - (1 << index));
            return b;
        }

        /// <summary>
        /// 将第index位取反 (从低位开始)
        /// </summary>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte ReverseBit(this byte b, int index)
        {
            b ^= (byte)(1 << index);
            return b;
        }

        #endregion

        #region ToMemoryStream

        /// <summary>
        /// 转换为内存流
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }

        #endregion
    }
}
