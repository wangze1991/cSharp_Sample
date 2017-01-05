using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace 数据采集
{
    /// <summary>
    /// 获取A站情感综合消息
    /// </summary>
    public class WebHtml:IRegexHtml
    {
      
        public  void ParseHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var rec = doc.DocumentNode.SelectSingleNode("//div[@id='block-content-article']/div[@class='mainer']");
            if (rec != null)
            {
                //var itemNode = rec.SelectNodes("div[@class='item']//a[@class='title']");
                var itemNode = rec.SelectNodes("div[@class='item']//a[@class='title']");
                Console.Clear();
                if (itemNode == null || !itemNode.Any()) {
                    Console.WriteLine("没有数据");
                    return;
                }
                foreach (var item in itemNode)
                {
                    Console.WriteLine(item.InnerText);
                }
            }
        }
    }
}
