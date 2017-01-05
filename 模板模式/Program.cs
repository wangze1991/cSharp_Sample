using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace 模板模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Poster registerPoster = new RegisterEamil("wangze@qq.com");
            Poster.SendEmail(registerPoster);
            Console.WriteLine("做其他事情");
            Console.ReadKey();
        }
    }
}
