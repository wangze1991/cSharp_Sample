using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static  class DateTimeHelper
    {
        /// <summary>
        /// 转换date样式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static string ShortTime(this DateTime dt, string formatter = "")
        {
            if (formatter.IsNullOrEmpty()) return dt.ToString("yyyy-MM-dd");
            return dt.ToString(formatter);
        }
    }
}
