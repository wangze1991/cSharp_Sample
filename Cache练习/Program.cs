using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Cache练习
{
    class Program
    {
        static void Main(string[] args)
        {
 
           HttpRuntime.Cache.Insert("pwd", "123", null, DateTime.Now.AddSeconds(5), Cache.NoSlidingExpiration);
           Console.WriteLine(HttpRuntime.Cache["pwd"].ToString());
           Thread.Sleep(5000);
           if (HttpRuntime.Cache["pwd"] != null)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("cache移除");
            }
            Console.ReadKey();

        }
    }
}
