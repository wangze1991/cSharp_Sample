using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace 自定义枚举
{

    public static class AppStateEnum {

        static AppStateEnum() {
            Name = "z";
            Value = 1;
        }

        public static string Name { get;private set; }
        public static int Value { get; private set; }
    }
    class Program
    {
        private static readonly Random _r = new Random(47);
        static void Main(string[] args)
        {

            Task.Factory.StartNew(() => {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                writeWithCache();
                sw.Stop();
                Console.WriteLine("有缓存 {0}", sw.Elapsed.TotalSeconds);
            
            
            });
            Task.Factory.StartNew(() =>
            {
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                writeNoCache();
                sw2.Stop();
                Console.WriteLine("无缓存 {0}",sw2.Elapsed.TotalSeconds);
            });
         
           Console.ReadKey();
        }
        static void writeWithCache()
        {
            for (int i = 0; i <1000000; i++)
            {
                EnumHelper.GetEnumDescriptionWithCache(AuditStateEnum.Yes);
    
            }
        }
        static void writeNoCache()
        {
            for (int i = 0; i < 1000000; i++)
            {
                EnumHelper.GetEnumDescriptionNoCache(AuditStateEnum.Yes);

            }
        }
        static void createRandomNumber() {
            Random r = new Random();
                string number = "";      
                for (int i = 0; i < 6; i++)
                {
                    number += r.Next(0, 10).ToString();
                }
                Console.WriteLine(number);
          
            }

        }
    
}
