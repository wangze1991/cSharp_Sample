using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivony.Data;
using Ivony.Data.Common;
using Ivony.Data.Queries;
using Ivony.Data.SqlClient;

namespace 数据采集
{
    public abstract class BookGatherBase
    {

        protected virtual string BookUrl { get; set; }

        private static readonly SqlDbExecutor _db = SqlServer.Connect(".", "BookDB");

        public BookGatherBase()
        {

        }


        protected virtual void InsertDb(Book book){
            _db.T(@"
            INSERT INTO [dbo].[Book]
           ([BookName]
           ,[Classify]
           ,[DownloadHits]
           ,[Author]
           ,[BookSorceUrl]
           ,[BookDownLoadUrl]
           ,[BookUpdateTime]
           ,[BookSize]
           ,[BookSizeUnit]
           ,[IsEnd]
           ,[MonthHits]
           ,[WeekHits]
           ,[TotalHits]
           ,[MonthRecommend]
           ,[WeekRecommend]
           ,[TotalRecommend]
           ,[Collection]
           ,[Profile])
     VALUES
           ({0}
           ,{1}
           ,{2}
           ,{3}
           ,{4}
           ,{5}
           ,{6}
           ,{7}
           ,{8}
           ,{9}
           ,{10}
           ,{11}
           ,{12}
           ,{13}
           ,{14}
           ,{15}
           ,{16}
           ,{17}
            ");
        }


    }
}
