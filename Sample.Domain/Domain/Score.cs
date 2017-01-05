using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{
    public class Score:BaseEntity
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int Marks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Student Student { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Course Course { get; set; }
    }
}
