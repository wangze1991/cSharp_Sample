using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
namespace 正则获取内容
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uri uri = new Uri("dotamax.com");
            //HttpClient client = new HttpClient();
            //string body = await client.(uri.ToString());
            try
            {


                Uri uri = new Uri("http://dotamax.com");
                WebRequest webRequst = WebRequest.Create(uri);
                webRequst.BeginGetResponse(x =>
                {
                    var request = x.AsyncState as WebRequest;
                    if (request != null)
                    {
                        WebResponse response = request.EndGetResponse(x);
                        Stream stream = response.GetResponseStream();

                        using (StreamReader reader = new StreamReader(stream))
                        {
                           string str = "\r\n";
                           str += reader.ReadToEnd();
                           StreamWriter sw=  File.AppendText(@"d:\dotamax.txt");
                           sw.WriteLine(str);
                           sw.Flush();
                           sw.Close();
                           Console.WriteLine("操作成功");
                        }
                        response.Close();
                        request.Abort();
                    }

                }, webRequst);
                Console.WriteLine("做其他事情");
                Console.ReadKey();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
