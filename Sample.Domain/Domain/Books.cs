using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{
    /// <summary>
    /// 图书馆书籍
    /// </summary>
    public  class Book:BaseEntity
    {
        public Book() {
        }
        /// <summary>
        /// 书名
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 书籍CSDN号
        /// </summary>
        public string BookIdCard { get; set; }

        /// <summary>
        /// 学生Id
        /// </summary>
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }


    }
}
