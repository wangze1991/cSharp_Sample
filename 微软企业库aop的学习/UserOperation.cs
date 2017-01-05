using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 微软企业库aop的学习
{
    public interface IUserOperation {
        void Test1(User oUser);
        void Test2(User oUser,User oUser2);
    }
    public class UserOperation : MarshalByRefObject, IUserOperation
    {
        public UserOperation() {
        }

        public string Name { get; set; }

        [LogHandler(LogInfo ="Test1的日志")]
        public void Test1(User oUser)
        {
            Console.WriteLine("Test1执行了");
        }
        [LogHandler(LogInfo ="Test2的日志")]
        public void Test2(User oUser, User oUser2)
        {
            Console.WriteLine("Test2执行了");
        }
    }
}
