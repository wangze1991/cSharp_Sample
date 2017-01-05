using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Office
{
    /// <summary>
    /// 格式化接口
    /// </summary>
    public interface IFormatter
    {
        object Format(object value);
    }
}
