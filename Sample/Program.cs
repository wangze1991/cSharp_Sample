using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            "1,23,4,5".Split(',').ToList().ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
            return;
            string testString = "Stream!Hello World";
            byte[] buffer = null;
            byte[] outBuffer = null;
            char[] testChar = null;
            string stringResult = "";
            buffer = Encoding.UTF8.GetBytes(testString);
            using (MemoryStream ms = new MemoryStream())
            {
                int count = ms.CanRead ? 3 : 0;
                //ms.Read(buffer, 0, count);
                ms.Write(buffer, 0, count);
                long newPostion = count + 1;//当前位置
                Console.WriteLine("当前位置是{0}", newPostion);
                newPostion = ms.Seek(3, SeekOrigin.Current);//获取偏移量
                ms.Write(buffer, (int)newPostion, buffer.Length - (int)newPostion);
                ms.Seek(0, SeekOrigin.Begin);
                outBuffer = new byte[ms.Length];
                ms.Read(outBuffer, 0, (int)ms.Length);
                int charCount = Encoding.UTF8.GetCharCount(outBuffer, 0, (int)ms.Length);
                testChar = new char[charCount];
                Encoding.UTF8.GetDecoder().GetChars(outBuffer, 0, (int)ms.Length, testChar, 0);
                Console.Write(testChar.Aggregate(stringResult, (current, s) => current + s));
                Console.ReadKey();
            }
        }
    }
}