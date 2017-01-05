using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 值传递和引用传递
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1=new Person();
            p1.Name = "张三";
            Person p2 = p1;
            p2.Name = "李四";
            Console.WriteLine(p2.Name);
            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
