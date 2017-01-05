using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 观察者模式
{
    /// <summary>
    /// 定义观察者接口
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// 消息通知
        /// </summary>
        /// <param name="msg"></param>
        void Notice(Subject subject);
    }
}
