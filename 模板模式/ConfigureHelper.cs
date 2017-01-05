using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板模式
{
    /// <summary>
    /// 读取配置文件
    /// </summary>
    public static class ConfigureHelper
    {
        /// <summary>
        /// 根据key获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValueWithKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
