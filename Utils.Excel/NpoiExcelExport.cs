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


namespace Utils.Excel
{
    public class NpoiExcelExport : IExport
    {
        private HSSFWorkbook _workbook;
        private ISheet _sheet;

        public NpoiExcelExport()
            : this("sheet1")
        {
        }


        public NpoiExcelExport(string sheetName)
        {
            _workbook = new HSSFWorkbook();
            _sheet = _workbook.CreateSheet(sheetName);
        }


        public NpoiExcelExport(Stream stream)
        {

            _workbook = new HSSFWorkbook(stream);
            //默认获取第一个sheet
            _sheet = _workbook.GetSheetAt(0);

        }


        public void MergeCell(int firstRow, int lastRow, int firstCol, int lastCol)
        {
            CellRangeAddress address = new CellRangeAddress(firstRow, lastRow, firstCol, lastCol);
            _sheet.AddMergedRegion(address);
        }

        public void FillData<T>(int x, int y, T data)
        {
            IRow row = GetRow(x);
            ICell cell = GetCell(row, y);
            cell.SetCellValue(data == null ? "" : data.ToString());
        }

        public void SetHeadStyle(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        public void SetRowsStyle(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private IRow GetRow(int rowIndex)
        {
            return _sheet.GetRow(rowIndex) ?? _sheet.CreateRow(rowIndex);
        }
        /// <summary>
        /// 获取列
        /// </summary>
        /// <param name="row"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private ICell GetCell(IRow row, int colIndex)
        {
            return row.GetCell(colIndex) ?? row.CreateCell(colIndex);
        }

    }
}
