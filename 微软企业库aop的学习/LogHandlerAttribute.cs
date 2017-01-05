using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace 微软企业库aop的学习
{
    public class LogHandlerAttribute:HandlerAttribute
    {
        public string LogInfo { get; set; }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LogHandler() { Order=Order, LogInfo = LogInfo };
        }
    }

    public class LogHandler : ICallHandler
    {
       /// <summary>
        /// 执行顺序
        /// </summary>
       public int Order { get; set; }

       public string LogInfo { get; set; }

        /// <summary>
        /// 拦截方法，可以规定在执行之前和之后拦截
        /// </summary>
        /// <param name="input"></param>
        /// <param name="getNext"></param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("LogInfo内容:{0}",LogInfo);
            var arrInputs = input.Inputs;//获取方法的输入参数
            if (arrInputs.Count > 0)
            {
               
            }
            //执行方法之前的拦截
            Console.WriteLine("方法执行前拦截到了");

            //执行方法
            var messageReturn = getNext()(input,getNext);

            //执行方法之后
            Console.WriteLine("方法执行后");
            Console.ReadKey();
            return messageReturn;
        }
    }
}
