using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Utils;
namespace 数据采集
{
    public class QiShuGather:BookGatherBase 
    {
        //http://www.qswtxt.com/class_{0}_{1}.html


        protected override string BookUrl
        {
            get
            {
                return "http://www.qswtxt.com/class_{0}_{1}.html";
            }
        }


        public async Task GetBookString(BookClassify classify,int size)
        {
            await GetBookString(classify, 1, size);
        }


        public async Task GetBookString(BookClassify classify, int start=1,int end=1)
        {

            for (int p = start; p <= end; p++)
            {
                string url = this.BookUrl.StringFormat((int)classify, p);
                await GetSinglePageBook(url);
            }

       
        }

        private async Task GetSinglePageBook(string url)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(await NetHelper.GetWebHtml(url));
            HtmlNodeCollection bookNameCollection = doc.DocumentNode.SelectNodes("//*[@id=\"listbox\"]/div[@class=\"mainListInfo\"]");
            for (var i = 0; i < bookNameCollection.Count; i++)
            {
                var node = bookNameCollection[i];
                var bookNameNode = node.SelectSingleNode("./div[@class=\"mainListName\"]/span[@class=\"mainSoftName\"]/a");
                var downLoadNode = node.SelectSingleNode("./div[@class=\"mainListSize\"]");
                var updateNode = node.SelectSingleNode("./div[@class=\"mainListDate\"]/span");
                var descriptionNode = node.SelectSingleNode("./following-sibling::div[@class=\"mainListIntro\"]");
                Console.WriteLine("书籍名称：{0},详细信息地址：{3},下载次数：{1},更新时间:{2}", bookNameNode.InnerText, downLoadNode.InnerText, updateNode.InnerText, bookNameNode.Attributes["href"].Value);
                Console.WriteLine("简介:{0}", descriptionNode.InnerText);
            }
        }
    }
}
