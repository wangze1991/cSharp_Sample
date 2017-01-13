using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace 数据采集
{
    public class NetHelper
     {
        private static readonly HttpClient client = new HttpClient();
         /// <summary>
         /// 根据HttpClient获取html
         /// </summary>
         /// <param name="url"></param>
         /// <returns></returns>
         public static Task<string> GetWebHtml(string url)
         {
             if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("url地址为空");
                client.Timeout = TimeSpan.FromSeconds(10);
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                response.Content.Headers.Add("charset", "gbk");
                return response.Content.ReadAsStringAsync();
         }

         public static Task<string> GetHtmlByWebClient(string url)
         {
             try
             {
                 using (WebClient wc = new WebClient())
                 {
                     wc.Encoding = Encoding.Default;
                     return wc.DownloadStringTaskAsync(url);
                 }
             }
            catch
            {
                 return Task.Run<string>(() => { return ""; });
             }
         }

         public static async Task<int> GetHtmllength(string url)
         {
             HttpClient hc = new HttpClient();
             var getStringTask = hc.GetStringAsync(url);
             return (await getStringTask).Length;
         }
    }
}
