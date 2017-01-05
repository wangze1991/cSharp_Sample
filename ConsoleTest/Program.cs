using Sample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Repository;
using System.Reflection;
namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] list = { 1,2,3,4,5,6};
            Console.WriteLine(list);
            Console.ReadKey();

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
}
