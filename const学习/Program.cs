using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstLib;
namespace const学习
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SomeType.ConstField);
            Console.WriteLine(SomeType.ReadonlyField);
            Console.ReadKey();
        }
    }
}
