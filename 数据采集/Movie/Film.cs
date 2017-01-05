using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据采集.Movie
{
    public class Film
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alternate { get; set; }

        public string Tags { get; set; }

        public string Region { get; set; }

        public int Year { get; set; }

        /// <summary>
        /// 提供链接下载时间
        /// </summary>
        public DateTime? ReleaseTime { get; set; }

        /// <summary>
        /// 编辑
        /// </summary>
        public string Editor { get; set; }


        public string Director { get; set; }

        public string Imdb { get; set; }

        public string DownloadUrl { get; set; }
    }
}
