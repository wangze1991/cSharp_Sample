using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public class MobileFactory
    {
        public static Mobile GetMobile(string name) {
            switch (name.ToLower())
            {
                case "xiaomi":
                    return new XiaoMi();
                case "iphone":
                    return new IPhone();
                default: return null;
            }
        }
    }
}
