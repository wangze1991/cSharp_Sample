using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据采集
{
    /// <summary>
    /// 过滤数据接口
    /// </summary>
    public interface IRegexHtml
    {
        void ParseHtml(string html);
    }
}
