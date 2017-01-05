using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace WCF.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host=new ServiceHost(typeof(Sample.Domain.People)))
            {
                host.Open();
                Console.WriteLine("Wcf服务已经启动");
                Console.ReadLine();
            }
        }
    }
}
