using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂模式
{
    public abstract class Mobile
    {
        public virtual void Call() {
            Console.WriteLine("这是普通手机拨打电话");
        }
    }
}
