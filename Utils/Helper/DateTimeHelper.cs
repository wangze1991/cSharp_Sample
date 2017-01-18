using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Helper
{
    /// <summary>
    /// DateTime帮助类
    /// </summary>
    public static class DateTimeHelper
    {

        #region 扩展方法
        /// <summary>
        /// dateTime转换为string
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="formatter">格式类型</param>
        /// <returns>日期:string</returns>
        /// <remarks>
        /// 如果formatter为空，则默认为yyyy-MM-dd
        /// </remarks>
        public static string format(this DateTime dt,string formatter="") {
            if (formatter.IsBlank()) {
                formatter = "yyyy-MM-dd";
            }
            return dt.ToString(formatter);
        }


        public static TimeSpan TimeInterval(DateTime t1,DateTime t2){
            return (t1 - t2);
        }
        /// <summary>
        /// 获取当前月份所在季节
        /// </summary>
        /// <returns></returns>
        public static int GetSeason() {
            return (int)Math.Ceiling(DateTime.Now.Month / 3.0);
        }

        /// <summary>
        /// 获取当前月份所在季度的开始时间和结束时间
        /// </summary>
        /// <returns></returns>
        public static DateTimeRange GetCurrentSeasonTimeRange()
        {
            DateTime startQuarter = DateTime.Now.AddMonths(0 - (DateTime.Now.Month - 1) % 3).AddDays(1 - DateTime.Now.Day);  //本季度初  
            DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末 
            return new DateTimeRange(startQuarter, endQuarter);
        }
        /// <summary>
        ///  获取当前月份上个季度的开始时间和结束时间
        /// </summary>
        /// <returns></returns>
        public static DateTimeRange GetLastSeasonTimeRange() {
            DateTime startQuarter = DateTime.Now.AddMonths(-3 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day);
            DateTime endQuarter = DateTime.Now.AddMonths(0 - ((DateTime.Now.Month - 1) % 3)).AddDays(1 - DateTime.Now.Day).AddDays(-1);
            return new DateTimeRange(startQuarter, endQuarter);
        }

        #endregion


        public class DateTimeRange {

            public DateTimeRange(DateTime begin,DateTime end) {
                this.TimeBegin = begin;
                this.TimeEnd = end;
            
            }
            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime TimeBegin { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public DateTime TimeEnd { get; set; }
        
        }
    }
}
