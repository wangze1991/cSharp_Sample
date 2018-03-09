using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1230冒泡排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = {10, 123, 123, 22, 23, 14, 5, 8, 3, 1, 7};
            int temp = 0;
            for (int i = 0; i < intArray.Length-1; i++)
            {
                for (int j = 0; j < intArray.Length - 1 - i; j++)
                {
                    if (intArray[j] > intArray[j + 1])
                    {
                        temp = intArray[j];
                        intArray[j] = intArray[j + 1];
                        intArray[j + 1] = temp;
                    }
                }

            }
            foreach (var i in intArray)
            {
                Console.Write(" {0}",i);
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
