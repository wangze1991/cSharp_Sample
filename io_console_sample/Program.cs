using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace io_console_sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                FileStream fs = new FileStream(@"d:\a.txt", FileMode.Append);
                string content = "江苏省常州市武进区";
                byte[] buffer = Encoding.Default.GetBytes(content);
                fs.Write(buffer, 0, buffer.Length);
                fs.WriteAsync
                fs.Close();

                string str = "亲，你好吗？亲，你好吗？亲，你好吗？亲，你好吗？";
                for (int i = 0; i < 20; i++)
                {
                    str += str;
                }
                //using (FileStream fs1 = File.OpenWrite(@"h:\2.txt"))
                //{
                //    //CompressionMode.Compress 压缩
                //    using (GZipStream zip = new GZipStream(fs1, CompressionMode.Compress))
                //    {
                //        byte[] tBytes = Encoding.UTF8.GetBytes(str);
                //        zip.Write(tBytes, 0, tBytes.Length);
                //    }
                //}
                //https://www.cnblogs.com/tangge/archive/2012/10/30/2746458.html
                //new StreamTest().excute();
                //查看源码 referencesource.commicrosoft
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}