using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{

    /// <summary>
    /// 类型转换
    /// </summary>
    public static class ConverHelper
    {
        /// <summary>
        /// string转换为int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
       public static int ToInt(this string str)
       {
            return Conv.ToInt(str);
       }
        /// <summary>
        /// 匿名对象转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="sample"></param>
        /// <returns></returns>
        public static T Cast<T>(this object obj,T sample){
            if (obj is T) return (T)obj;
            return default(T);
        }
    }
}
