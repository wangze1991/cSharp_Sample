using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 值传递和引用传递
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "张三";
            Person p2 = p1;
            p2.Name = "李四";
            p1 = null;
            Console.WriteLine(p2.Name);
            changeName(ref p2);
            Console.WriteLine(p2.Name);
            Console.ReadKey();
        }

        private static void changeName(ref Person p)
        {
            p.Name = "11111";
            p = new Person();
            p.Name = "22222";
        }

        public static T getValue<T>(T str)
        {
            return str;
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public void f1()
        {
            Console.WriteLine(Program.getValue(1));
        }
    }
}