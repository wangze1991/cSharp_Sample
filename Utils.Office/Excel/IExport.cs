using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Office
{
    /// <summary>
    /// 导出接口
    /// </summary>
    public interface IExport
    {
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="firstRow"></param>
        /// <param name="lastRow"></param>
        /// <param name="firstCol"></param>
        /// <param name="lastCol"></param>
        void MergeCell(int firstRow,int lastRow,int firstCol,int lastCol);
        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="x">rowIndex</param>
        /// <param name="y">colIndex</param>
        /// <param name="data">数据</param>
        void FillData(int x, int y, object data);
        /// <summary>
        /// 设置表头样式
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void SetHeadStyle(int x1, int y1, int x2, int y2);
        /// <summary>
        /// 设置行样式
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void SetRowsStyle(int x1, int y1, int x2, int y2);


        /// <summary>
        /// 设置表格标题样式
        /// </summary>
        /// <param name="colSpan"></param>
        void SetHeadTitleStyle(int colSpan);

        Stream SaveAsStream();
    }
}
