using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 微软企业库aop的学习
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User() {Name="王泽",PassWord="123123" };
            PolicyInjection.Create<UserOperation,IUserOperation>().Test1(user);
            Console.ReadKey();
        }
    }
}
