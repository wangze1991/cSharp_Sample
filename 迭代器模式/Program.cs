using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Iterator<Friend> i;
            Person p = new Person();
            p.Friends.Add(new Friend() { Name = "张三", Sex = "男" });
            p.Friends.Add(new Friend() { Name = "美女", Sex = "女" });
            i = p.GetEnumerator();
            while (i.MoveNext())
            {
                var item = i.Current;
                Console.WriteLine("{0}:{1}",item.Name,item.Sex);
            }
            Console.ReadKey();
        }
    }
}
