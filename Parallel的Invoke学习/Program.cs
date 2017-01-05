using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Parallel的Invoke学习
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Parallel.Invoke(TaskOne, TaskTwo);
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed);
            //sw.Reset();
            //Console.ReadKey();


            ParallelFor();
            Console.ReadKey();
        }

        static void ParallelFor() {
            Stopwatch watch=Stopwatch.StartNew();
            watch.Start();
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Parallel.For(0, 3000000, x =>
            {
                bag.Add(x);
            });
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }

        static void TaskOne() {
            Thread.Sleep(3000);
            Console.WriteLine("我是任务1");

        }
        static void TaskTwo() {
            Thread.Sleep(5000);
            Console.WriteLine("我是任务2");

        }
    }
}
