using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面试题
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array=GetBalance(10000,2200,new int[7]{0,1,10,10,10,10,10});
            int[] perValue = { 10000, 5000, 2000, 1000, 500, 100, 10 };
            if (array == null)
            {
                Console.WriteLine("无法找零");
                Console.ReadKey();
                return;
            }
            for (int i = 0; i < perValue.Length; i++)
            {
               Console.WriteLine("找零{0}：\t {1}张",perValue[i],array[i]);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 售货机
        /// </summary>
        /// <param name="total">总金额</param>
        /// <param name="price">价格</param>
        /// <param name="reserved"></param>
        /// <returns></returns>
        //10000
        //5000
        //2000
        //1000
        //500
        //100
        //10
        public static int[] GetBalance(int total, int price, int[] reserved)
        {

            //int sum = reserved.Sum();
            int[] resultArray = new int[7];
            int balance = total - price;
           // if (sum < balance) return null;
            int[] perValueArray = {10000,5000,2000,1000,500,100,10};
            for (int i = 0; i <7; i++)
            {
                balance = ChildrenMethod(balance, perValueArray[i], resultArray, i, reserved);
                if (i == 6)
                {
                    if (balance != 0)
                    {
                        return null;
                    }
                }
            }
            return resultArray;
        }

        /// <summary>
        /// 返回余额
        /// </summary>
        /// <param name="balance">余额</param>
        /// <param name="perValue">面值</param>
        /// <param name="resultArray">输出数组</param>
        /// <param name="number">当前面值在数组中的位置</param>
        /// <param name="currentArray">当前售货机存储的总数</param>
        /// <returns></returns>
        public static int ChildrenMethod(int balance, int perValue, int[] resultArray, int number,int[] currentArray)
        {
            var perCount = balance / perValue;
            if (currentArray[number] > 0)
            {
                if (perCount > 0)
                {
                    if (perCount > currentArray[number])
                    {
                        resultArray[number] = currentArray[number];
                        return balance - currentArray[number]*perValue;
                    }
                    resultArray[number] = perCount;
                    return balance - perCount*perValue;
                }
                resultArray[number] = 0;
                return balance;
            }
            resultArray[number] = 0;
            return balance;
        }

    }
}
