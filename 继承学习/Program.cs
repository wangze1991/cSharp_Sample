using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 继承学习
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent c = new Children("王泽");
            Parent b = new Children("小李");
            int[] array1 = { 1, 2, 3 };
            int[] array2 = new[] { 1, 2, 3 };
            int[] array3 = new int[] { 1, 2, 3 };
            int[] array4 = new int[3];
            IList<Parent> parents = new[] { c, b };

            //Console.WriteLine(c.field);
            //Console.ReadKey();
            //Enumerable.Range(1, 10).ToList().ForEach(new Program().Write);
            //Console.ReadKey();
            List<int> list = new List<int> { 1, 2, 3, 4 };
            list.ForEach(x =>
            {
                x++;
            });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            List<int?> referceList = new List<int?>() { 1, 2, 3, 4 };
            referceList.Select(x => { return x++; });
            foreach (var item in referceList)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }

        void Write(int number)
        {
            Console.WriteLine("我是写方法:{0}", number);
        }
    }

    public class Parent : IComparable<Parent>
    {
        private int _m1;
        public int field = 1;
        public Parent()
        {
            Console.WriteLine("我是父类的构造方法");
        }
        public virtual void WriteField()
        {
            Console.WriteLine("我是父类的field:{0}", this.field);
        }

        //public Parent(string parentName)
        //{
        //    Console.WriteLine("我是父类的构造方法，我是{0}",parentName);
        //}

        public int CompareTo(Parent other)
        {
            throw new NotImplementedException();
        }
    }

    public class Children : Parent
    {
        public int field = 2;
        public Children()
        {
            Console.WriteLine("我是子类的构造方法");
        }
        public override void WriteField()
        {
            Console.WriteLine("我是父类的field:{0}", base.field);
            Console.WriteLine("我是子类的field:{0}", this.field);
            Console.WriteLine("我是field:{0}", field);
        }

        public Children(string childrenName)
        {
            Console.WriteLine("我是子类的构造方法，我是{0}", childrenName);
        }
    }
}

namespace wz
{
    public class Ai
    {
        protected string S { get; set; }
    }


}
