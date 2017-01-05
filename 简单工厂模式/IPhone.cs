using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public class IPhone:Mobile
    {
        public override void Call()
        {
            Console.WriteLine("这是IPhone手机拨打的电话");
        }
    }
}
