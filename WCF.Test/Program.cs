using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.Test.Host;

namespace WCF.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            FlyClient flyClient=new FlyClient();
            flyClient.Open();
          var str=  flyClient.Fly("王泽");
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
