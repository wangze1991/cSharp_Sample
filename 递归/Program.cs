using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 递归
{
    class Program
    {
        /** 1,2,3,5,7,13,21,34,55,89
         */
        static void Main(string[] args)
        {
            int[] a = new int[30];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = progress(i);
            }
            foreach (var item in a)
            {
                Console.Write("{0},", item);
            }
            Console.ReadKey();

        }
        static int progress(int i){
            if (i == 0) return 1;
            if (i == 1) return 2;
            return progress( i - 1) + progress( i - 2);
     }
    }
}
