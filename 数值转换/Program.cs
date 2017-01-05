using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数值转换
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 11;
            double c = a / b;
            Console.WriteLine(a/b);
            Console.WriteLine((a / b).ToString("p"));
            Console.WriteLine(((a/b)).ToString("p"));
            Console.WriteLine(c.ToString("p"));
            Console.ReadKey();
        }
    }
}
