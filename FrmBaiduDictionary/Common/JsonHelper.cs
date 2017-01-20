using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FrmBaiduDictionary.Common
{
    
    public static  class JsonHelper
    {

        /// <summary>
        /// string 转json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(this string str)where T:class
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
           return JsonConvert.DeserializeObject<T>(str);
        }
        /// <summary>
        /// override
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static object DeserializeJson(this string str)
        {
            return JsonConvert.DeserializeObject(str);
        }
        /// <summary>
        /// 转换为json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj,new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }
    }
}
