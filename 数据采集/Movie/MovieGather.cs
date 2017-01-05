using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Utils;
using System.Net;
namespace 数据采集
{
    public class MovieGather
    {
        public Uri MovieUrl { get;private set; }

        public int Page { get; set; }


        public MovieGather(int page) {
            this.MovieUrl = new Uri("http://www.bttiantang.com/");
            this.Page = page;
        }

        public async Task  GetPageHtml()
        {
            for(var i=1;i<=this.Page;i++){
                var url = new Uri(MovieUrl, "?PageNo=" + i);
                await GetHtml(url.AbsoluteUri);
            }
       
        }


        public async Task GetHtml(string url)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(await NetHelper.GetWebHtml(url));
            var nodes = doc.DocumentNode.SelectNodes(@"//div[@class=""ml""]//div[@class=""title""]/p[@class=""tt cl""]/a");
            if (nodes == null) return;
            foreach(var node in nodes){
                var relativeUrl = node.Attributes["href"];
                if (relativeUrl == null || string.IsNullOrWhiteSpace(relativeUrl.Value)) continue;
                var redirectUrl = new Uri(MovieUrl, relativeUrl.Value);
                var childDoc = new HtmlDocument();
                childDoc.LoadHtml(await NetHelper.GetWebHtml(redirectUrl.AbsoluteUri));
                var detail = childDoc.DocumentNode.SelectNodes(@"//ul[@class=""moviedteail_list""]/li");//获取详情 div
                for (var i = 0; i < detail.Count; i++)
                {
                    Console.WriteLine(detail[i].InnerText);
                }
            }
        }


     }
         
    
}
