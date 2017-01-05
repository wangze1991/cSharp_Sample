using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Utils.Office
{
    /// <summary>
    /// 获取数据接口
    /// </summary>
    public interface IApiData
    {
        object GetData(HttpContext context);
    }
}
