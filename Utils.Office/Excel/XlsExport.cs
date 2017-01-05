using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using System.IO;


namespace Utils.Office
{
    public class XlsExport : IExport
    {
        private HSSFWorkbook _workbook;
        private ISheet _sheet;
        public XlsExport()
        {
            _workbook = new HSSFWorkbook();
            _sheet = _workbook.CreateSheet("sheet1");
            //_sheet.DefaultRowHeight = 200 * 20;
        }

        public void MergeCell(int firstRow, int lastRow, int firstCol, int lastCol)
        {
            CellRangeAddress address = new CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
            _sheet.AddMergedRegion(address);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">所在行</param>
        /// <param name="y">所在列</param>
        /// <param name="field"></param>
        /// <param name="data"></param>
        public void FillData(int x, int y, object data)
        {
            var row = GetRow(x);
            var cell = GetCell(row, y);
            cell.SetCellValue(data.ToString());
        }


        public void SetHeadStyle(int x1, int y1, int x2, int y2)
        {
            for (var i = x1; i <= x2; i++)
            {
                var row = GetRow(i);
                for (var j = y1; j <= y2; j++)
                {
                    var cell = GetCell(row, j);
                    cell.CellStyle = GetHeadStyle();
                }
            }
        }

        public void SetRowsStyle(int x1, int y1, int x2, int y2)
        {
            for (var i = x1; i <= x2; i++)
            {
                var row = GetRow(i);
                for (var j = y1; j <= y2; j++)
                {
                    var cell = GetCell(row, j);
                    cell.CellStyle = GetDataStyle();
                }
            }
        }
        public void SetHeadTitleStyle(int colSpan)
        {
            MergeCell(0, 0, 0, colSpan-1);
            for (var j = 0; j <= colSpan-1; j++)
            {
                var row = GetRow(0);
                var cell = GetCell(row, j);
                cell.CellStyle = GetHeadStyle();
            }
        }

        public Stream SaveAsStream()
        {
            //TODO注意关闭文件流
            Stream ms = new MemoryStream();
            this._workbook.Write(ms);
            return ms;

        }

        #region 私有方法

        IRow GetRow(int rowIndex)
        {
            return _sheet.GetRow(rowIndex) ?? _sheet.CreateRow(rowIndex);
        }
        ICell GetCell(IRow row, int colIndex)
        {
            return row.GetCell(colIndex) ?? row.CreateCell(colIndex);
        }

        /// <summary>
        /// 这是导入获取值的类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        string GetCellValue(ICell cell)
        {
            if (null == cell) return string.Empty;
            object obj = null;
            switch (cell.CellType)
            {
                case CellType.Boolean:
                    obj = cell.BooleanCellValue;
                    break;
                case CellType.Numeric:
                    if (HSSFDateUtil.IsCellDateFormatted(cell)) obj = cell.DateCellValue;
                    else obj = cell.NumericCellValue;
                    break;
                case CellType.String:
                    obj = cell.StringCellValue.Trim();
                    break;
                case CellType.Unknown:
                case CellType.Blank:
                case CellType.Error:
                default: break;
            }
            return (obj ?? string.Empty).ToString();
        }

        ICellStyle GetHeadStyle()
        {
            //表头样式
            var headStyle = _workbook.CreateCellStyle();
            headStyle.Alignment = HorizontalAlignment.Center;//居中对齐
            headStyle.VerticalAlignment = VerticalAlignment.Center;

            //表头单元格背景色
            headStyle.FillForegroundColor = HSSFColor.LightGreen.Index;
            //headStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
            //表头单元格边框
            headStyle.BorderTop = BorderStyle.Thin;
            headStyle.TopBorderColor = HSSFColor.Black.Index;
            headStyle.BorderRight = BorderStyle.Thin;
            headStyle.RightBorderColor = HSSFColor.Black.Index;
            headStyle.BorderBottom = BorderStyle.Thin;
            headStyle.BottomBorderColor = HSSFColor.Black.Index;
            headStyle.BorderLeft = BorderStyle.Thin;
            headStyle.LeftBorderColor = HSSFColor.Black.Index;
            //表头字体设置
            var font = _workbook.CreateFont();
            font.FontHeightInPoints = 12;//字号
            font.Boldweight = 600;//加粗
            //font.Color = HSSFColor.WHITE.index;//颜色
            headStyle.SetFont(font);

            return headStyle;
        }

        ICellStyle GetDataStyle()
        {
            //数据样式
            var dataStyle = _workbook.CreateCellStyle();
            dataStyle.Alignment = HorizontalAlignment.Left;//左对齐
            //数据单元格的边框
            dataStyle.BorderTop = BorderStyle.Thin;
            dataStyle.TopBorderColor = HSSFColor.Black.Index;
            dataStyle.BorderRight = BorderStyle.Thin;
            dataStyle.RightBorderColor = HSSFColor.Black.Index;
            dataStyle.BorderBottom = BorderStyle.Thin;
            dataStyle.BottomBorderColor = HSSFColor.Black.Index;
            dataStyle.BorderLeft = BorderStyle.Thin;
            dataStyle.LeftBorderColor = HSSFColor.Black.Index;
            //数据的字体
            var datafont = _workbook.CreateFont();
            datafont.FontHeightInPoints = 11;//字号
            dataStyle.SetFont(datafont);

            return dataStyle;
        }

        ICellStyle GetHeadTitleStyle()
        {
            var headStyle = _workbook.CreateCellStyle();
            headStyle.Alignment = HorizontalAlignment.Center;//居中对齐
            headStyle.VerticalAlignment = VerticalAlignment.Center;
            var font = _workbook.CreateFont();
            font.FontHeightInPoints = 12;//字号
            font.Boldweight = 600;//加粗
            //font.Color = HSSFColor.WHITE.index;//颜色
            headStyle.SetFont(font);
            return headStyle;
        }
        #endregion



    }
}
