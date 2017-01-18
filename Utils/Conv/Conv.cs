using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Utils
{
    public static class Conv
    {
    

        #region 数值转换

        /// <summary>
        /// 转换int类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt<T>(T data)
        {
            return Conv.ToNullableInt(data) ?? 0;
        }

        /// <summary>
        /// 转换为可空泛型int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToNullableInt<T>(T data)
        {
            if (data == null || Convert.IsDBNull(data)) return null;
            int result = 0;
            return int.TryParse(data.ToString(), out result) ? result : default(int?);
        }

        /// <summary>
        /// 转换为double类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>double</returns>
        public static double ToDouble<T>(T data)
        {
            return Conv.ToNullableDouble(data) ?? 0d;
        }

        /// <summary>
        /// 转换为可空泛型double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToNullableDouble<T>(T data)
        {
            if (data == null || Convert.IsDBNull(data)) return null;
            double result = 0d;
            return double.TryParse(data.ToString(), out result) ? result : default(double?);
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <returns></returns>
        public static decimal ToDecimal<T>(T data)
        {
            return Conv.ToNullableDecimal(data) ?? 0m;
        }

        /// <summary>
        /// 转换为可空泛型decimal
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal<T>(T data)
        {
            if (data == null||  Convert.IsDBNull(data)) return null;
            decimal result = 0m;
            return decimal.TryParse(data.ToString(), out result) ? result : default(decimal?);
        }

        #endregion 数值转换

        /// <summary>
        /// 转换为guid
        /// </summary>
        /// <param name="data"></param>
        /// <returns>如果为空 则返回Guid.Empty</returns>
        public static Guid ToGuid<T>(T data)
        {
            return Conv.ToNullableGuid(data) ?? Guid.Empty;
        }

        /// <summary>
        /// 转换为可空泛型guid
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Guid?</returns>
        public static Guid? ToNullableGuid<T>(T data)
        {
            if (data == null || Convert.IsDBNull(data)) return null;
            Guid guid = Guid.Empty;
            return Guid.TryParse(data.ToString(), out guid) ? guid : default(Guid?);
        }

        #region bool值转换

        /// <summary>
        /// bool值转换
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool ToBool(object data)
        {
            if (data == null || data == DBNull.Value) return false;
            switch (data.ToString().ToLower())
            {
                case "0":
                    return false;

                case "1":
                    return true;

                case "是":
                    return true;

                case "否":
                    return false;

                case "yes":
                    return true;

                case "no":
                    return false;

                default: return false;
            }
        }

        #endregion bool值转换

        #region 日期转化

        /// <summary>
        /// 返回日期类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>如果转换不成功，返回当前时间</returns>
        /// <remarks>
        /// 方法一：Convert.ToDateTime(string)
        ///string格式有要求，必须是yyyy-MM-dd hh:mm:ss
        /// 方法二：Convert.ToDateTime(string, IFormatProvider)
        /// DateTime dt;
        ///DateTimeFormatInfo dtFormat = new System.GlobalizationDateTimeFormatInfo();
        ///dtFormat.ShortDatePattern = "yyyy/MM/dd";
        ///dt = Convert.ToDateTime("2011/05/26", dtFormat);
        /// 方法三：DateTime.ParseExact()
        /// string dateString = "20110526";
        ///DateTime dt = DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
        ///DateTime dt = DateTime.ParseExact(dateString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
        /// </remarks>
        public static DateTime ToDateTime<T>(T data ,string formatter="yyyy-MM-dd") {
            return Conv.ToNullableDouble(data, formatter) ?? new DateTime();
        }

        public static DateTime? ToNullableDouble<T>(T data, string formatter = "yyyy-MM-dd")
        {
            if (data == null || Convert.IsDBNull(data)) return null;
            try
            {
                return DateTime.ParseExact(data.ToString(), formatter, System.Globalization.CultureInfo.CurrentCulture);
            }
            catch {
                return null;
            }

        }

        #endregion 日期转化

        #region dataTable转换

        /// <summary>
        ///
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable table)
        {
            return "";
        }

        /// <summary>
        /// DataRow转实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T GetEntity<T>(DataRow row) where T : new()
        {
            T entity = new T();
            foreach (var item in entity.GetType().GetProperties())
            {
                if (row.Table.Columns.Contains(item.Name))
                {
                    if (DBNull.Value != row[item.Name])
                    {
                        //判断是否是泛型类
                        if (!item.PropertyType.IsGenericType)
                        {
                            item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                        }
                        else
                        {
                            Type genericTypeDefinition = item.PropertyType.GetGenericTypeDefinition();
                            if (genericTypeDefinition == typeof(Nullable<>))
                            {
                                item.SetValue(entity, Convert.ChangeType(row[item.Name], Nullable.GetUnderlyingType(item.PropertyType)), null);
                            }
                        }
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// DataTable转Poco
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetList<T>(DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0) return null;
            var list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetEntity<T>(row));
            }
            return list as IEnumerable<T>;
        }

        #endregion dataTable转换

        
    }
}