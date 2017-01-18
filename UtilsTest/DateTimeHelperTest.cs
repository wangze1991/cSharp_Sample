using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Helper;
namespace UtilsTest
{
    [TestClass]
    public class DateTimeHelperTest
    {
        [TestMethod]
        public void TestGetLastSeason() {
         DateTimeHelper.DateTimeRange range=   DateTimeHelper.GetLastSeasonTimeRange();
         Console.WriteLine(range.TimeBegin.ToString("yyyy-MM-dd"));
         Console.WriteLine(range.TimeEnd.ToString("yyyy-MM-dd"));   
         
        }

        [TestMethod]
        public void TestTime() {

            DateTime t1 = new DateTime(2016, 1, 21,20,18,20);
            DateTime t2 = DateTime.Now;
            TimeSpan ts=t2-t1;
            Console.WriteLine("TimeSpan的Days:{0}", ts.Days);//间隔时间，不算小时，分钟
            Console.WriteLine("TimeSpan的Hours:{0}", ts.Hours);//间隔小时数，不算天数
            Console.WriteLine("TimeSpan的Minutes:{0}", ts.Minutes);
            Console.WriteLine("TimeSpan的TotalDays:{0}", ts.TotalDays);//间隔时间，算小时，分钟
        
        
        }

    }
}
