using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
namespace FrmBaiduDictionary.Common
{
    public static class WebClientHelper
    {

        readonly static Encoding _defaultEncoding = Encoding.Default;

        public async static Task<string> GetWebHtml(string url)
        {
            using (WebClient wc = new WebClient())
            {
                    wc.Encoding = _defaultEncoding;
                    return await wc.DownloadStringTaskAsync(url);
            }
        }
    }
}
