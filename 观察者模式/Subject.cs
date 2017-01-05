using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    /// <summary>
    /// 主题
    /// </summary>
    public abstract class Subject
    {
        public IList<IObserver> Observers { get; set; }
        public string Info { get; set; }
        public Subject() {
            this.Observers = new List<IObserver>();
        }
        /// <summary>
        /// 添加观察者
        /// </summary>
        /// <param name="oberver"></param>
        public abstract void Attach(IObserver observer);

        /// <summary>
        /// 移除观察者
        /// </summary>
        /// <param name="oberver"></param>
        public abstract void Detach(IObserver observer);

        /// <summary>
        /// 通知
        /// </summary>
        public virtual void Notify(string msg) {       
        }
    }
}
