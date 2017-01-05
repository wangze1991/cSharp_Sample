using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace FrmBaiduDictionary
{
    public class Word
    {
        const string _url = "http://openapi.baidu.com/public/2.0/translate/dict/simple";
        const string _clientId ="nk7H05NoXGajy7q1TlQlAm6j";
        public string From { get;private set; }

        public string To { get; private set; }

        public string Words { get; set; }

        public Word(string word)
        {
            this.Words = word;
            this.From = Words.IsChinese() ? "zh" : "en";
            this.To = Words.IsChinese() ? "en" : "zh";
        }

        /// <summary>
        /// 转换为URL链接
        /// </summary>
        /// <returns></returns>
        public string ToUrl() {
            return string.Format("{0}?client_id={1}&q={2}&from={3}&to={4}", _url,_clientId, this.Words.UrlEncode(), this.From, this.To);
        }
    }
}
