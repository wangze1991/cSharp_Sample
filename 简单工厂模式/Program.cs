using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Mobile xiaomiMobile = MobileFactory.GetMobile("xiaomi");
            xiaomiMobile.Call();
            Mobile iphoneMobile = MobileFactory.GetMobile("iphone");
            iphoneMobile.Call();
            Console.ReadKey();
            
        }
    }
}
