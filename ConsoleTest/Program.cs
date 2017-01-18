using Sample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Repository;
using System.Reflection;
using System.Threading;
namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            ThreadTest tt = new ThreadTest();

            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(tt.getA);
                Task.Factory.StartNew(tt.getB);
            }
            Console.ReadKey();

            //int[] list = { 1,2,3,4,5,6};
            //Console.WriteLine(list);
            //Console.ReadKey();

            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //IRepository<Student> studentRepository = new EfRepository<Student>(new SchoolContext());
            //Student student = new Student { ID = 1, StudentName = "王泽", Sex = PersonSex.Man };
            //studentRepository.Insert(student);
            //Console.WriteLine("添加成功");
            //var annoyObject = new {Name="王泽",Id=1};
            //var type = annoyObject.GetType();
            //foreach (var property in type.GetProperties())
            //{
            //    Console.WriteLine(property.Name);
            //    Console.WriteLine(property.GetValue(annoyObject));
            //}
            //StringFormat();
            //Console.ReadKey();

            //using (SchoolContext db = new SchoolContext())
            //{
            //    Student student = new Student { 
            //     ID=1,
            //     StudentName="王泽",
            //     Sex=PersonSex.Man,
            //    };
  
            //}
            //var b=new B();
            //b.Name = "111";
            //A a = new A(b);
            //Console.WriteLine(a.A_B.Name);
            //b.Name = "asdfasdf";
            //Console.WriteLine(a.A_B.Name);
            //Console.ReadKey();
        }
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception)args.ExceptionObject;
            Console.WriteLine(ex.Message);
        }

        static void StringFormat() {
            var date =DateTime.Now;
            Console.WriteLine("{0:yyyy-MM-dd HH:mm:ss}",date);
        
        }

    }
    public class A {
        public B A_B { get; private set; }
        public A( B b) {
            this.A_B = b;
        }
    }
    public class B {
        public string Name { get; set; }
    }


    public class ThreadTest
    {
        private Object thisLock = new Object();    

        public int i { get; set; }



        public void getA()
        {
            lock (thisLock)
            {
                i++;
                Thread.Sleep(1);
                Console.WriteLine(i);
            }
         
        }
        public void getB()
        {
            lock (thisLock)
            {
                i++;
                Thread.Sleep(1);
                Console.WriteLine(i);
            }
        }

    }

}
