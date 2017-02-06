using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Excel
{
    /// <summary>
    ///属性对应的单元格
    /// </summary>
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Class,AllowMultiple=true,Inherited=false)]
    public  class ExcelCellAttribute:Attribute
    {
        /// <summary>
        /// 是否是Excel表头
        /// </summary>
        public bool IsHead { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; set; }

        public ExcelCellAttribute(string title,int index) {
            this.Title = title;
            this.Index = index;
            this.IsHead = false;
        }

        public ExcelCellAttribute(string title, int index,bool isHead)
        {
            this.Title = title;
            this.Index = index;
            this.IsHead = isHead;
        }




    }
}
