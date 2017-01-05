using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmBaiduDictionary.Data
{
    public class BaiDuWord
    {
        /// <summary>
        /// 是否有错 0 没有错
        /// </summary>
        public int error { get; set; }
        /// <summary>
        /// 转换前的语言
        /// </summary>
        public string from { get; set; }
        /// <summary>
        /// 转换后的语言
        /// </summary>
        public string to { get; set; }

        /// <summary>
        /// 单词
        /// </summary>
        public string word_name { get; set; }

        public BaiduData data { get; set; }

        public BaiDuWord() {
        }
       
    }

    public class BaiduData {
        public string word_name { get; set; }
        public IList<Symbol> symbols { get; set; }
        public BaiduData() {
            this.symbols = new List<Symbol>();
        }
    }

    public class Symbol {
        public string ph_am { get; set; }
        public string ph_en { get; set; }
        public IList<Part> parts { get; set; }

        public Symbol() {
            this.parts = new List<Part>();
        }
    }

    public class Part {
        public IList<string> means { get; set; }
        public string part { get; set; }

        public Part() {
            this.means = new List<string>();
        }
    }
}
