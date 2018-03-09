using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型基础知识
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.Str = "1";
            List<A> list = new List<A>();
            list.Add(a);
            a.Str = "2";
            Console.WriteLine(list[0].Str);
            Console.ReadKey();
        }

        public void getValue(IList<string> a) 
        {

        }
    }

    class A {
        public string Str { get; set; }
    }
}
