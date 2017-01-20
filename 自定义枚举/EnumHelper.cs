using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Concurrent;


namespace 自定义枚举
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumHelper
    {
        static EnumHelper()
        {

        }

        /// <summary>
        /// 作为缓存存储
        /// </summary>
        private static readonly IDictionary<string, Tuple<string, int, string>> _cacheDict = new ConcurrentDictionary<string, Tuple<string, int, string>>();

        /// <summary>
        /// 根据枚举获取描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetEnumDescriptionWithCache(Enum @enum)
        {
            Type type = @enum.GetType();
            var key = type.ToString() + @enum.ToString();
            if ((_cacheDict.ContainsKey(key) && _cacheDict[key] != null) == false)
            {
                AddCache(@enum);
            }
            return _cacheDict[key].Item3;

        }
        public static string GetEnumDescriptionNoCache(Enum @enum)
        {
            string str = "";
            Type type = @enum.GetType();
            FieldInfo fd = type.GetField(@enum.ToString());
            object obj = fd.GetCustomAttribute(typeof(DescriptionAttribute), false);
            if (obj == null) return null;
            return (obj as DescriptionAttribute).Description;
        }
        private static void AddCache(Enum @enum)
        {
            Type type = @enum.GetType();
            //已经存在cache中，不添加

            FieldInfo[] infos = type.GetFields().Where(x=>!x.IsSpecialName).ToArray();
            foreach (FieldInfo info in infos)
            {
                var key = type.ToString() + info.Name;
                if (_cacheDict.ContainsKey(key) && _cacheDict[key] != null) continue;
                //_cacheDict.Add(key, info);
                string str ="";
                object[] obj = info.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (obj == null) continue;
                foreach (DescriptionAttribute attribute in obj)
                {
                    str += attribute.Description;
                }
                _cacheDict.Add(key, new Tuple<string, int, string>(info.Name, (int)info.GetValue(@enum), str));
            }

        }


    }
}
