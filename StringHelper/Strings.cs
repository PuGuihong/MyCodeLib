using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace StringHelper
{
    /// <summary>
    /// 创建人员：puguihong
    /// 创建时间：2016年02月25日
    /// 创建说明：字符串帮助类
    /// </summary>
    public class Strings
    {
        public static object HttpUtility { get; private set; }
        #region 获取字符串长度

        /// <summary>
        /// 获取字符串长度
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int GetStringLength(string s)
        {
            if (!string.IsNullOrEmpty(s))
                return Encoding.Default.GetBytes(s).Length;
            return 0;
        }

        /// <summary>
        /// 获取指定字符串中字符的个数
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int GetCharCount(string s, char c)
        {
            if (s == null || s.Length == 0) return 0;

            int count = 0;
            foreach (char a in s)
            {
                if (a == c) count++;
            }
            return count;
        }
        #endregion

        #region 分割字符串

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="splitStr">分隔字符串</param>
        /// <returns></returns>
        public static string[] SplitString(string sourceStr, string splitStr)
        {
            if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(splitStr))
                return new string[0] { };

            if (sourceStr.IndexOf(splitStr) == -1)
                return new string[] { sourceStr };

            if (splitStr.Length == 1)
                return sourceStr.Split(splitStr[0]);
            else
                return Regex.Split(sourceStr, Regex.Escape(splitStr), RegexOptions.IgnoreCase);

        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <returns></returns>
        public static string[] SplitString(string sourceStr)
        {
            return SplitString(sourceStr, ",");
        }

        #endregion

        #region 截取字符串

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="startIndex">开始位置的索引</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns></returns>
        public static string SubString(string sourceStr, int startIndex, int length)
        {
            if (!string.IsNullOrEmpty(sourceStr))
            {
                if (sourceStr.Length >= (startIndex + length))
                    return sourceStr.Substring(startIndex, length);
                else
                    return sourceStr.Substring(startIndex);
            }

            return "";
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns></returns>
        public static string SubString(string sourceStr, int length)
        {
            return SubString(sourceStr, 0, length);
        }

        #endregion

        #region 移除前导/后导字符串

        /// <summary>
        /// 移除前导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <returns></returns>
        public static string TrimStart(string sourceStr, string trimStr)
        {
            return TrimStart(sourceStr, trimStr, true);
        }

        /// <summary>
        /// 移除前导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string TrimStart(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr) || !sourceStr.StartsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                return sourceStr;

            return sourceStr.Remove(0, trimStr.Length);
        }

        /// <summary>
        /// 移除后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <returns></returns>
        public static string TrimEnd(string sourceStr, string trimStr)
        {
            return TrimEnd(sourceStr, trimStr, true);
        }

        /// <summary>
        /// 移除后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string TrimEnd(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr) || !sourceStr.EndsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                return sourceStr;

            return sourceStr.Substring(0, sourceStr.Length - trimStr.Length);
        }

        /// <summary>
        /// 移除前导和后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <returns></returns>
        public static string Trim(string sourceStr, string trimStr)
        {
            return Trim(sourceStr, trimStr, true);
        }

        /// <summary>
        /// 移除前导和后导字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <param name="trimStr">移除字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns></returns>
        public static string Trim(string sourceStr, string trimStr, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(sourceStr))
                return string.Empty;

            if (string.IsNullOrEmpty(trimStr))
                return sourceStr;

            if (sourceStr.StartsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                sourceStr = sourceStr.Remove(0, trimStr.Length);

            if (sourceStr.EndsWith(trimStr, ignoreCase, CultureInfo.CurrentCulture))
                sourceStr = sourceStr.Substring(0, sourceStr.Length - trimStr.Length);

            return sourceStr;
        }

        /// <summary>
        /// 移除前后字符串
        /// </summary>
        /// <param name="sourceStr">源字符串</param>
        /// <returns></returns>
        public static string Trim(object sourceStr)
        {
            if (sourceStr == null) return "";
            return sourceStr.ToString().Trim();
        }

        #endregion

        #region 转换Int类型
        /// <summary>
        /// 转换Int类型
        /// </summary>
        /// <param name="inputStr">待转字符串</param>
        /// <param name="Default">失败后默认值</param>
        /// <returns></returns>
        public static int ToInt(string inputStr, int result = 0)
        {
            int.TryParse(inputStr, out result);
            return result;
        }

        /// <summary>
        /// 转换Decimal类型
        /// </summary>
        /// <param name="inputStr">待转字符串</param>
        /// <param name="Default">失败后默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(string inputStr, decimal result = 0)
        {
            decimal.TryParse(inputStr, out result);
            return result;
        }
        #endregion

        #region 移除特殊字符
        /// <summary>
        /// 移除特殊字符
        /// </summary>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public static string RemoveTSZF(string inputstr)
        {
            return inputstr.Replace("\r", " ").Replace("\n", " ").Replace("'", " ").Replace("\"", " ");
        }
        #endregion

        #region 格式化时间
        /// <summary>
        /// 获取时间格式字符串
        /// </summary>
        /// <param name="t"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToDateTime(object obj, string format = "yyyy年MM月dd日")
        {
            if (obj == null || obj.ToString() == "") return "";
            DateTime t;
            if (DateTime.TryParse(obj.ToString(), out t) && t != DateTime.MinValue)
            {
                return t.ToString(format);
            }
            return string.Empty;
        }
        #endregion

        #region 编码解码
        /// <summary>
        /// 进行URL编码，UTF8
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string URLEncode(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            return System.Web.HttpUtility.UrlEncode(str, Encoding.UTF8);
        }

        /// <summary>
        /// 进行URL解码，UTF8
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string URLDecode(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            return System.Web.HttpUtility.UrlDecode(str, Encoding.UTF8);
        }
        #endregion

        /// <summary>
        /// 获取字符串指定长度
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="len">指定长度</param>
        /// <returns>字符串</returns>
        public static string GetStrByLen(string source, int len)
        {
            if (!string.IsNullOrEmpty(source))
            {
                if (source.Trim().Length > len)
                {
                    return source.Substring(0, len);
                }
            }

            return source;
        }

    }
}
