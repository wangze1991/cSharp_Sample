using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wz.AutoMapper.Sample.Dto
{
    public class ArticleDto
    {
        /// <summary>
        /// 文章Id
        /// </summary>
        public string ArticleId { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 文章摘要
        /// </summary>
        public string Summary { get; set; }


        public string Author { get; set; }

        public string Content { get; set; }


        public DateTime PostTime { get; set; }

        public int PostYear { get; set; }

        public string Remark { get; set; }

    }
}
