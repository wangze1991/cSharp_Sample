using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据采集
{
    class Program
    {
        static void Main(string[] args)
        {
           // QiShuGather qishu = new QiShuGather();
            //Task.WaitAll(qishu.GetBookString(BookClassify.玄幻魔法,100));
            MovieGather movie = new MovieGather(10);
            Task.WaitAll(movie.GetPageHtml());

            Console.ReadKey();

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
