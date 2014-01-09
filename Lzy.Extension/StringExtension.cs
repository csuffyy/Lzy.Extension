using System;
using System.Text.RegularExpressions;

namespace Lzy.Extension
{
    /// <summary>
    /// String类型的扩展方法
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 扩展：string.IsNullOrEmpty
        /// </summary>
        /// <param name="s"></param>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// 扩展：Regex.IsMatch
        /// </summary>
        /// <param name="s">要测试的字符串</param>
        /// <param name="pattern">要匹配的pattern.</param>
        /// <returns><c>true</c> if the specified s is match; otherwise, <c>false</c>.</returns>
        public static bool IsMatch(this string s, string pattern)
        {
            return s != null && Regex.IsMatch(s, pattern);
        }

        /// <summary>
        /// Matches the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>System.String.</returns>
        public static string Match(this string s, string pattern)
        {
            if (s == null)
            {
                return "";
            }
            return Regex.Match(s, pattern).Value;
        }

        /// <summary>
        /// Determines whether the specified s is int.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if the specified s is int; otherwise, <c>false</c>.</returns>
        public static bool IsInt32(this string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>转换失败返回0</returns>
        public static int ToInt32(this string s)
        {
            int i;
            int.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// To the double.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>转换失败返回0</returns>
        public static double ToDouble(this string s)
        {
            double i;
            double.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// To the datetime.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>转换失败返回 DateTime默认值（最小值）:0001/1/1 0:00:00 </returns>
        public static DateTime ToDateTime(this string s)
        {
            DateTime i;
            DateTime.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// 转换成camel命名
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string ToCamel(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }
            return s[0].ToString().ToLower() + s.Substring(1);
        }

        /// <summary>
        /// 转换成Pascal命名
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>System.String.</returns>
        public static string ToPascal(this string s)
        {
            if (s.IsNullOrEmpty())
            {
                return s;
            }
            return s[0].ToString().ToUpper() + s.Substring(1);
        }
        
        /// <summary>
        /// If扩展:若符合特定条件则执行操作
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="predicate">条件</param>
        /// <param name="func">操作</param>
        /// <returns>若满足条件，返回执行后的结果，反之返回本身</returns>
        public static string If(this string s, Predicate<string> predicate, Func<string, string> func)
        {
            return predicate(s) ? func(s) : s;
        }
    }
}
