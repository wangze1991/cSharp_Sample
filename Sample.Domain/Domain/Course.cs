using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{
    public class Course:BaseEntity
    {
        public Course() {
            this.Scores = new HashSet<Score>();
        }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// 教师名称
        /// </summary>
        public string TeacherName { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
    }
}
