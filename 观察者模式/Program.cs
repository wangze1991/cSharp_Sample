using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new ConcreteSubject();
            var observer = new Observer("王泽");
            subject.Attach(observer);
            subject.Notify("订阅号发布了一条通知");
            Console.ReadKey();
        }
    }
}
