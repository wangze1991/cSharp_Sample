using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    public class ConcreteSubject:Subject
    {
        public override void Attach(IObserver observer)
        {
            this.Observers.Add(observer);
        }
        public override void Detach(IObserver observer)
        {
            this.Observers.Remove(observer);
        }

        /// <summary>
        /// 发布一条公共信息
        /// </summary>
        public override void Notify(string msg)
        {
            this.Info = msg;
            if (this.Observers.Any()) {
                this.Observers.ToList().ForEach(x => {
                    x.Notice(this);
                });
            
            }
        }
    }
}
