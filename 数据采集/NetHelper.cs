﻿using System;
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
        public async static Task<String> GetWebHtml(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("url地址为空");
            client.Timeout = TimeSpan.FromSeconds(10);
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            response.Content.Headers.Add("charset", "gbk");
            return await response.Content.ReadAsStringAsync();
        }

        public async static Task<byte[]> getImageContent(string url)
        {
            using (WebClient wc = new WebClient())
            {
                return await wc.DownloadDataTaskAsync(url);
            }
        }

        public static Task<string> GetHtmlByWebClient(string url)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
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