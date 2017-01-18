using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils.Helper
{
    public static class StringHelper
    {
        #region 扩展方法

        /// <summary>
        /// str格式化
        /// </summary>
        /// <param name="str">格式化参数</param>
        /// <param name="strArray">替换参数</param>
        /// <returns>string</returns>
        public static string StringFormat(this string str, params object[] strArray)
        {
            return string.Format(str, strArray);
        }
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true 为空，false为不为空</returns>
        /// <remarks>
        /// (如果是空字符,也返回false)
        /// </remarks>
        public static bool IsBlank(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 判断是否不为空`
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true：不为空并且不为空字符串，false为空</returns>
        public static bool IsNotBlank(this string str)
        {
            return !str.IsBlank();
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">截取长度</param>
        /// <param name="replaceStr">替换字符串默认为...</param>
        /// <returns>string</returns>
        public static string Subset(this string str, int length, string replaceStr = "...")
        {
            if (str.IsBlank()) return "";
            int strLength = str.Length;
            if (length == 0 || length >= str.Length) { return str; }
            return str.Substring(0, length) + replaceStr;
        }
        /// <summary>
        /// 判断是否为中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChinese(this string str)
        {
            if (str.IsBlank()) return false;
            var isChinese = true;
            str.ToCharArray().ToList().ForEach(x =>
            {
                if (!Regex.IsMatch(x.ToString(), @"[\u4e00-\u9fbb]"))
                {
                    isChinese = false;
                    return;
                }
            });
            return isChinese;
        }
        /// <summary>
        ///url编码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string UrlEncode(this string str)
        {
            if (str == null)
                return null;
            return WebUtility.UrlEncode(str);
        }
        /// <summary>
        /// url解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(this string str)
        {
            if (str == null)
            {
                return null;
            }
            return WebUtility.UrlEncode(str);
        }
        public static bool Regx(this string str, string pattern)
        {
            return Regex.IsMatch(str, pattern);
        }


        #endregion
    }
}
