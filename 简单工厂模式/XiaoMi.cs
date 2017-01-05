using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public class XiaoMi:Mobile
    {
        public override void Call()
        {
            Console.WriteLine("这是小米手机拨打的电话");
        }
    }
}
