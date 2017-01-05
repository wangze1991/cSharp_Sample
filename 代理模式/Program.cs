using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("我有车,但是我不会开车，我需要有人开车");
            IDrive proxyDrive = new Proxy(new Driver("我是司机"));
            proxyDrive.Drive();
            Console.ReadKey();
        }
    }
}
