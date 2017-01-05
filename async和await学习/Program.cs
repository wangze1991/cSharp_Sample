using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async和await学习
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("主线程开始");
            Write();
            Console.WriteLine("主线程结束");
            Console.ReadKey();
        }
        static async Task Write() {
            await WriteAsync();
        }

        static async Task WriteAsync() {
            for(var i = 0; i < 5; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Console.WriteLine("异步操作{0}", i);
            }
        }
    }
}
