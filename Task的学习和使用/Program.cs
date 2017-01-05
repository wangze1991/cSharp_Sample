using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task的学习和使用
{
    class Program
    {
        static void Main(string[] args)
        {

            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // var cts = new CancellationTokenSource();
            // var t1 = Task_Await().ContinueWith(x => { Task_Await_Another(); });
            //Task.WaitAll(t1);
            // sw.Stop();
            // Console.WriteLine(sw.ElapsedMilliseconds);
            // Console.ReadKey();
            // Define the cancellation token.
            try
            {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
           
            var task = Task.Run(() => {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(2000);

                Console.WriteLine("我是任务1");
            },token);
            source.Cancel();
            Task.WaitAll(task);
            Console.ReadKey();
            }
            catch (Exception ex)
            {
                if (ex is AggregateException)
                {
                    foreach (var e in (ex as AggregateException).InnerExceptions)
                    {
                        Console.WriteLine("\nhi,我是OperationCanceledException:{0}\n",e.Message);
                    }
                }
                Console.ReadKey();
            }
        }


        static void createTaskInstance()
        {
            Task task = new Task(() =>
            {
                Console.WriteLine("我是任务1");
            });
            Task taskAnother = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("我是任务2");
            });
            Console.WriteLine("任务还未开始");
            Console.WriteLine("任务1的状态:{0}", task.Status);
            Console.WriteLine("任务2的状态:{0}", taskAnother.Status);
            Console.WriteLine("任务开始了。。。。。");
            task.Start();
            Console.WriteLine("任务一的状态:{0}", task.Status);
            Console.WriteLine("任务二的状态：{0}", taskAnother.Status);
            Console.ReadKey();
        }
        static void createAwaitTask()
        {
            Task.Run(() => { Task_One(); });
            Task_Await();

        }
        static void Task_One()
        {
            Thread.Sleep(2000);
            Console.WriteLine("当前线程的ID：{0}", Task.CurrentId);
            Console.WriteLine("我是任务1");
        }
        static void Task_Two()
        {
            Thread.Sleep(4000);
            Console.WriteLine("当前线程的ID：{0}", Task.CurrentId);
            Console.WriteLine("我是任务二");
        }
        static Task Task_Await()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("当前线程的ID：{0}", Task.CurrentId);
                Console.WriteLine("我是异步的方法1");

            });
        }
        static Task Task_Await_Another()
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("当前线程的ID：{0}", Task.CurrentId);
                Console.WriteLine("我是异步的方法2");
            });
            return task;
        }

        static void CancelTask() {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Random rnd = new Random();
            Object lockObj = new Object();

            List<Task<int[]>> tasks = new List<Task<int[]>>();
            TaskFactory factory = new TaskFactory(token);
            for (int taskCtr = 0; taskCtr <= 10; taskCtr++)
            {
                int iteration = taskCtr + 1;
                tasks.Add(factory.StartNew(() =>
                {
                    int value;
                    int[] values = new int[10];
                    for (int ctr = 1; ctr <= 10; ctr++)
                    {
                        lock (lockObj)
                        {
                            value = rnd.Next(0, 101);
                        }
                        if (value == 0)
                        {
                            source.Cancel();
                            Console.WriteLine("Cancelling at task {0}", iteration);
                            break;
                        }
                        values[ctr - 1] = value;
                    }
                    return values;
                }, token));

            }
            try
            {
                Task<double> fTask = factory.ContinueWhenAll(tasks.ToArray(),
                                                             (results) =>
                                                             {
                                                                 Console.WriteLine("Calculating overall mean...");
                                                                 long sum = 0;
                                                                 int n = 0;
                                                                 foreach (var t in results)
                                                                 {
                                                                     foreach (var r in t.Result)
                                                                     {
                                                                         sum += r;
                                                                         n++;
                                                                     }
                                                                 }
                                                                 return sum / (double)n;
                                                             }, token);
                Console.WriteLine("The mean is {0}.", fTask.Result);
                Console.ReadKey();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Unable to compute mean: {0}",
                                          ((TaskCanceledException)e).Message);
                    else
                        Console.WriteLine("Exception: " + e.GetType().Name);
                }
                Console.ReadKey();
            }
        
        
        }
    }
}
