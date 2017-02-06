using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Utils.Excel
{
    /// <summary>
    /// Excel帮助类
    /// </summary>
    public class ExcelHelper
    {
        //传递List，导出Excel(没有模版)
        public void Export<T>(IExport exportImpl, IEnumerable<T> list)
        {
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties(System.Reflection.BindingFlags.Public);
            Attribute classAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(ExcelCellAttribute));
            int headIndex = 0;
            //设置表头
            if (classAttribute != null && classAttribute is ExcelCellAttribute)
            {
                if (propertyInfos != null && propertyInfos.Length > 0)
                {
                    ExcelCellAttribute excelClassCellAttribute = classAttribute as ExcelCellAttribute;
                    if (excelClassCellAttribute.IsHead == true)
                    {
                        exportImpl.MergeCell(0, 0, 0, propertyInfos.Length - 1);
                        exportImpl.FillData(0, 0, excelClassCellAttribute.Title);
                        headIndex++;
                    }

                }
            }
            //设置列名
            if (propertyInfos != null && propertyInfos.Length > 0)
            {
                headIndex++;
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    Attribute propertyAttribute = Attribute.GetCustomAttribute(propertyInfo, typeof(ExcelCellAttribute));
                    if (propertyAttribute != null && propertyAttribute is ExcelCellAttribute)
                    {
                        ExcelCellAttribute excelPropertyCellAttribute = propertyAttribute as ExcelCellAttribute;
                        exportImpl.FillData(headIndex, excelPropertyCellAttribute.Index, excelPropertyCellAttribute.Title);
                    }
                }
            }
            //填充数据
            if (list != null && list.Any())
            {
                int rowIndex = ++headIndex;
                if ((propertyInfos != null && propertyInfos.Length > 0) == false) return;
                foreach (T item in list)
                {
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        Attribute propertyAttribute = Attribute.GetCustomAttribute(propertyInfo, typeof(ExcelCellAttribute));
                        if (propertyAttribute != null && propertyAttribute is ExcelCellAttribute)
                        {
                            ExcelCellAttribute excelPropertyCellAttribute = propertyAttribute as ExcelCellAttribute;
                            exportImpl.FillData(rowIndex, excelPropertyCellAttribute.Index, propertyInfo.GetValue(item));
                        }
                    }
                }
            }
        }
    }
}
