using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    /// <summary>
    /// 工资调剂
    /// </summary>
    public class WageSwap
    {
        /// <summary>
        /// 主键
        /// </summary>
        public  int id { get; set; }

        /// <summary>
        /// 工资主键
        /// </summary>
        public virtual System.Nullable<int> wageId { get; set; }

        /// <summary>
        /// 调剂金额
        /// </summary>
        public virtual System.Nullable<double> swapMoney { get; set; }
        /// <summary>
        /// 根据swaptype 获取swapTypeValue
        /// </summary>
        public virtual System.Nullable<int> swapTypeValue { get; set; }

        /// <summary>
        /// 标识大类 swap：调剂 rewards：奖金 otherWage：其他奖金 
        /// </summary>
        public virtual string swapType { get; set; }


        /// <summary>
        /// 用户ID
        /// </summary>
        public virtual System.Nullable<int> userId { get; set; }


        /// <summary>
        /// 年份
        /// </summary>
        public virtual System.Nullable<int> years { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public virtual System.Nullable<int> months { get; set; }
    }
}
