using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Domain
{
    public class StudentAddress:BaseEntity

    {
        /// <summary>
        /// 外键StudentId  1*0,1
        /// </summary>
        public int StudentId { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string City { get; set; }
        public string ZipAddress { get; set; }

        public virtual Student Student { get; set; }
    }
}