using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Domain
{
    /// <summary>
    /// 抽象基类
    /// </summary>
    public abstract class BaseEntity
    {
        public virtual int ID { get; set; }

        public virtual byte[] RowVersion { get; set; }
    }
}