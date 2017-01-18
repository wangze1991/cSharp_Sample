using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Collections;
using System.IO;
using Utils.Helper;
using Newtonsoft.Json.Linq;
namespace Utils.Office
{
    /// <summary>
    /// 导出
    /// </summary>
    public class Exporter
    {
        /// <summary>
        /// EasyUi Columns
        /// </summary>
        private List<List<Column>> _titles;

        private IExport _export;
        /// <summary>
        /// 获取数据
        /// </summary>
        private object _dataSource;

        public string  _head;



        public static Exporter Instance()
        {
            var current = HttpContext.Current;
            var exporter = new Exporter();
            if (current.Request["titles"].IsNotBlank())
            {
                exporter.SetTitle(JsonConvert.DeserializeObject<List<List<Column>>>(current.Request["titles"]));
            }
            //exporter.SetExport(export);
            //exporter.SetDataSource(new ApiData());
            return exporter;

        }

        public Exporter SetHead(string headName) {
            _head = headName;
            return this;
        }

        public Exporter SetTitle(List<List<Column>> titles)
        {
            this._titles = titles;
            return this;
        }
        public Exporter SetExport(IExport export)
        {
            this._export = export;
            return this;
        }
        public Exporter SetDataSource(IApiData data)
        {
            this._dataSource = data.GetData(HttpContext.Current);
            return this;
        }


        private Exporter()
        {
        }

        public Exporter Export()
        {
            try
            {
                int currentRowIndex =_head.IsBlank()?0:1, currentColIndex = 0;
                Dictionary<int, int> currenteHeadRow = new Dictionary<int, int>();//放置单元格所占行数
                Dictionary<int ,string> fieldIndex = new Dictionary<int, string>();//获取每列元素所对应的
                Func<int, int> getCurrentHeadRow = cell => currenteHeadRow.ContainsKey(cell) ? currenteHeadRow[cell] : 0;   
                #region 设置表头，包含多表头
                for (int i = 0; i < _titles.Count; i++)
                {
                    currentColIndex = 0;//当前列
                    for (int j = 0; j < _titles[i].Count; j++)
                    {
                        var column = _titles[i][j];
                        if (column.hidden) continue;
                        while ( getCurrentHeadRow(currentColIndex)>i)
                        {
                            currentColIndex++;
                        }

                        _export.FillData(currentRowIndex, currentColIndex, column.title);
                        //判断是否要合并单元格
                        if (column.rowspan + column.colspan > 2)
                        {
                            this._export.MergeCell(currentRowIndex, currentRowIndex + column.rowspan - 1, currentColIndex, currentColIndex + column.colspan - 1);
                        }
                        //记录每一列所对应的field
                        if (column.colspan == 1 && column.field.IsNotBlank())
                        {
                            fieldIndex[currentColIndex] =column.field;
                        }
                        //如果跨列，则为每列记录当前单元格跨的行数rowspan
                        for (int k = 0; k < column.colspan; k++)
                        {
                            currenteHeadRow[currentColIndex] = getCurrentHeadRow(currentColIndex++) + column.rowspan;
                        }
                    }
                    _export.SetHeadStyle(currentRowIndex, 0, currentRowIndex, currentColIndex - 1);

                    currentRowIndex++;
                }
                #endregion
                #region  设置标题样式
                if (_head.IsNotBlank())
                {
                    _export.FillData(0, 0, _head);
                    _export.SetHeadTitleStyle(fieldIndex.Count);
                }
                #endregion
                #region 填充数据
                //填充数据
                var index = _head.IsBlank()? 0 : 1;
                foreach (var x in (_dataSource as IEnumerable<dynamic>))
                {
                    foreach (var item in fieldIndex)
                    {
                        if (x is JObject)
                        {
                            _export.FillData(index + _titles.Count, item.Key, (x as JObject).Property(item.Value.ToLower()).Value.ToString());
                        }
                    }
                    _export.SetRowsStyle(index + _titles.Count, 0, index + _titles.Count, fieldIndex.Count - 1);//设置数据样式
                    index++;
                }
                #endregion
              
                return this;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DownLoad()
        {
            var stream = _export.SaveAsStream();
            HttpHelper.DownloadExcel(stream, Path.Combine(DateTime.Now.ToString("yyyyMMdd"), ".xls"));
            return;
        }
    }
}
