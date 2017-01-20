using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自定义枚举
{
    public enum AuditStateEnum
    {
        [Description("待审核")]
        ToDo=1,
        [Description("审核通过")]
        Yes=2,
        [Description("审核不通过")]
        No=4
        
    }
}
