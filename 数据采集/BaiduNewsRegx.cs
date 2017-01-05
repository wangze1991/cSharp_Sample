using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace 数据采集
{
    public class BaiduNewsRegx : IRegexHtml
    {
        public void ParseHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var ulNodes = doc.DocumentNode.SelectNodes("//ul[@class='ulist focuslistnews']");
            Console.Clear();
            if (!(ulNodes != null && ulNodes.Any())) { Console.WriteLine("没有数据");return; }
            foreach (var ulItem in ulNodes)
            {
                var aTag = ulItem.SelectNodes("./li/a");
                if (aTag != null && aTag.Any())
                {
                    foreach (var aItem in aTag)
                    {
                        //Console.WriteLine("标题:{0},地址:{1}", aItem.InnerText, aItem.Attributes["href"].Value);
                        Console.WriteLine(aItem.InnerText);
                    }

                }
            }
        }
    }
}
