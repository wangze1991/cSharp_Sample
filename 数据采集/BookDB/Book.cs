using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据采集
{
    public class Book
    {

        public int BookId { get; set; }

        /// <summary>
        /// 书籍名称
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 书籍分类
        /// </summary>
        public BookClassify Classify { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        public int DownloadHits { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 书籍来源地址
        /// </summary>
        public string BookSorceUrl { get; set; }

        /// <summary>
        /// 下载地址
        /// </summary>
        public string BookDownLoadUrl { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime BookUpdateTime { get; set; }
        /// <summary>
        /// 字数
        /// </summary>
        public long BookSize { get; set; }

        /// <summary>
        /// 字数单位
        /// </summary>
        public string  BookSizeUnit { get; set; }

        /// <summary>
        /// 是否完结
        /// </summary>
        public bool IsEnd { get; set; }

        public long MonthHits { get; set; }

        public long WeekHits {get;set; }

        public long TotalHits { get; set; }

        public long MonthRecommend { get; set; }

        public long WeekRecommend { get; set; }

        /// <summary>
        /// 总推荐数
        /// </summary>
        public long TotalRecommend { get; set; }

        /// <summary>
        /// 收藏总数
        /// </summary>
        public long Collection { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Profile { get; set; }
    }
}
