using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 结构sample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("请输入要交换的数字");
                int arrayLength =Convert.ToInt32(Console.ReadLine());
                Random radom=new Random();
                int[] intArray=new int[arrayLength];
                for (int i = 0; i < arrayLength; i++)
                {
                    intArray[i] = radom.Next(1, 101);
                }
                Console.Write("原数组是: ");
                foreach (var i in intArray)
                {
                    Console.Write(" {0} ",i);
                }
                var actionLength =  arrayLength/2 ;
                if (actionLength > 0)
                {
                    //int[] newArray = new[arrayLength];
                    int temp = 0;
                    for (int i = 0; i < actionLength; i++)
                    {
                        temp = intArray[i];
                        intArray[i] = intArray[arrayLength - 1-i];
                        intArray[arrayLength - 1-i] = temp;

                    }
                    Console.Write("\r\n翻转后数组为: ");
                    foreach (var i in intArray)
                    {
                        Console.Write(" {0} ",i);
                    }
                }
                Console.ReadKey();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
