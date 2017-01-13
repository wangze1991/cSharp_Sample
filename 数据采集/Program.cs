using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace 数据采集
{
    class Program
    {
        private static readonly object _obj = new object();
        //private static readonly string DANGEROUS_WORD =new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        private static readonly string DANGEROUS_WORD = "*";
        static void Main(string[] args)
        {
            // QiShuGather qishu = new QiShuGather();
            //Task.WaitAll(qishu.GetBookString(BookClassify.玄幻魔法,100));
            //MovieGather movie = new MovieGather(10);
            //Task.WaitAll(movie.GetPageHtml());

            GetHtml().ContinueWith(x => {
                Console.WriteLine("写入技术");
            });
            Console.ReadKey();
            return;
            string url = "http://www.81xsw.com/0_179/";
            string html = NetHelper.GetHtmlByWebClient(url).Result;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes(@"//div[@id=""list""]//dd/a");
            if (nodes == null)
            {
                Console.WriteLine("查找节点为空");
                return;
            }
            string novelPath = @"d:\novel\";
            creteDirectory(novelPath);
            int i = 1;
            foreach (var node in nodes)
            {
                string relativeUrl = node.Attributes["href"].Value;
                string value = node.InnerText;
                string filePath = filterDangeroursWord(novelPath + i + "_" + value + ".txt");
                int j = i;
                NetHelper.GetHtmlByWebClient(url + "/" + relativeUrl).ContinueWith(x =>
                {

                    Console.WriteLine("进入获取内容{0}", j);
                    HtmlDocument contentDoc = new HtmlDocument();
                    contentDoc.LoadHtml(x.Result);
                    HtmlNode contentCode = contentDoc.DocumentNode.SelectSingleNode(@"//div[@id=""content""]");
                    using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                        {
                            sw.Write(contentCode.InnerText);
                            sw.Flush();

                            //sw.WriteAsync(contentCode.InnerText).ContinueWith(y =>
                            //{
                            //    Console.WriteLine(filePath);
                            //    sw.FlushAsync();

                            //});
                        }
                    }

                });

                i++;
            }
            Console.ReadKey();

        }

        static async Task GetHtml()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            string url = "http://www.81xsw.com/0_179/";
            string html = NetHelper.GetHtmlByWebClient(url).Result;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes(@"//div[@id=""list""]//dd/a");
            if (nodes == null)
            {
                Console.WriteLine("查找节点为空");
                return;
            }
            string novelPath = @"d:\novel\";
            creteDirectory(novelPath);
            int i = 1;
            foreach (var node in nodes.Take(3))
            {
                string relativeUrl = node.Attributes["href"].Value;
                string value = node.InnerText;
                string filePath = filterDangeroursWord(novelPath + i + "_" + value + ".txt");     
                HtmlDocument contentDoc = new HtmlDocument();
                Console.WriteLine("1主线程id:{0}", Thread.CurrentThread.ManagedThreadId);
                contentDoc.LoadHtml(await NetHelper.GetHtmlByWebClient(url + "/" + relativeUrl));
                Console.WriteLine("2主线程id:{0}", Thread.CurrentThread.ManagedThreadId);
                HtmlNode contentCode = contentDoc.DocumentNode.SelectSingleNode(@"//div[@id=""content""]");
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        Console.WriteLine(filePath);
                        await sw.WriteAsync(contentCode.InnerText);
                        Console.WriteLine("3主线程id:{0}", Thread.CurrentThread.ManagedThreadId);
                        await sw.FlushAsync();
                        Console.WriteLine("4主线程id:{0}", Thread.CurrentThread.ManagedThreadId);
                        Console.WriteLine(value+" 写入成功");

                    }
                }
                i++;
            }


            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }


        static string filterDangeroursWord(string path)
        {
            foreach (char c in DANGEROUS_WORD)
            {
                path = path.Replace(c, '_');
            }
            return path;
        }

        static void creteDirectory(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
        }

        //Console.WriteLine("查询中，请稍等...");
        //    //var url = "http://www.acfun.tv/v/list73/index_1.htm";
        //    var url = "http://news.baidu.com/";

        //    var task =NetHelper.GetHtmllength(url);
        //    task.Wait();
        //    Console.WriteLine(task.Result);
        //    //IRegexHtml regexHtml = new BaiduNewsRegx();
        //    //WebHtml.GetHtmlByWebClient(url).ContinueWith(x => {
        //    //    regexHtml.ParseHtml(x.Result);
        //    //});
        //    Console.ReadKey();
    }
}
