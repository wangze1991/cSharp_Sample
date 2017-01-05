using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    public class Observer:IObserver
    {
        public string Name { get; set; }

        public Observer(string name) {
            this.Name = name;
        }
        public void Notice(Subject subject)
        {
            Console.WriteLine("{0}收到订阅号的消息，消息为:{1}",this.Name,subject.Info);
        }
    }
}
