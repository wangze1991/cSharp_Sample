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
        /// 判断是否是手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        //public static bool IsPhone(this string str)
        //{
        //    if (str.IsNullOrEmpty()) return false;
        //    return str.Regx("^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$");
        //}
        /// <summary>
        /// 是否身份证号，验证如下3种情况：
        /// 1.身份证号码为15位数字；
        /// 2.身份证号码为18位数字；
        /// 3.身份证号码为17位数字+1个字母
        /// </summary>
        //public static bool IsIdentityCard(this string value)
        //{
        //    const string pattern = @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
        //    return value.Regx(pattern);
        //}
        //public static bool IsEmail(this string value)
        //{
        //    return value.Regx(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");
        //}

    }
}
