using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
namespace Utils
{

    /// <summary>
    /// string 扩展方法
    /// </summary>
    public static class StringHelper
    {
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
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
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
            if (str.IsNullOrEmpty()) return "";
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
            if (str.IsNullOrEmpty()) return false;
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
        ///转换为UT8字符编码
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
        /// <summary>
        /// 判断是否是手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPhone(this string str)
        {
            if (str.IsNullOrEmpty()) return false;
            return str.Regx("^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$");
        }
        /// <summary>
        /// 是否身份证号，验证如下3种情况：
        /// 1.身份证号码为15位数字；
        /// 2.身份证号码为18位数字；
        /// 3.身份证号码为17位数字+1个字母
        /// </summary>
        public static bool IsIdentityCard(this string value)
        {
            const string pattern = @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
            return value.Regx(pattern);
        }
        public static bool IsEmail(this string value)
        {
            return value.Regx(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");
        }

    }
}
