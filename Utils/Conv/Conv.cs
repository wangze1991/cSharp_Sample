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

        private static string key = "0000-0000-0000-0000";

        #region 数值转换
        /// <summary>
        /// 转换int类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(object str)
        {
            if (str == null || str == DBNull.Value) return 0;
            int result = 0;
            bool isValid = int.TryParse(str.ToString(), out result);
            if (isValid) return result;
            try
            {
                return Convert.ToInt32(ToDouble(str, 0));
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 转换为double类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>double</returns>
        public static double ToDouble(object obj)
        {
            if (obj == null || obj == DBNull.Value) return 0d;
            double result = 0d;
            double.TryParse(obj.ToString(), out result);
            return result;
        }
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="str"></param>
        /// <param name="digits">小数位数</param>
        /// <returns></returns>
        public static double ToDouble(object obj, int digits)
        {
            return Math.Round(ToDouble(obj), digits);
        }

        /// <summary>
        /// 转换为decimal
        /// </summary>
        /// <returns></returns>
        public static decimal ToDecimal(object data)
        {
            if (data == null || data == DBNull.Value) return 0m;
            decimal result = 0m;
            decimal.TryParse(data.ToString(), out result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }

        #endregion
        /// <summary>
        /// 转换为guid
        /// </summary>
        /// <param name="data"></param>
        /// <returns>如果为空 则返回Guid.Empty</returns>
        public static Guid ToGuid(object data)
        {
            if (data == null || data == DBNull.Value) return new Guid();
            Guid guid;
            return Guid.TryParse(data.ToString(), out guid) ? guid : Guid.Empty;
        }

        /// <summary>
        /// 转换为Guid?
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Guid?</returns>
        public static Guid? ToGuidOrNull(object data)
        {
            if (data == null || data == DBNull.Value) return null;
            Guid guid = new Guid();
            bool isValid = Guid.TryParse(data.ToString(), out guid);
            if (isValid) return guid;
            return null;
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


        #endregion

        #region 日期转化

        #endregion

        #region 通用转换
        public static T To<T>(object obj)
        {
            if (obj == null) return default(T);//如果为空  返回默认值
            if (obj is string && string.IsNullOrWhiteSpace(obj.ToString()))
                return default(T);
            Type type = typeof(T);
            try
            {
                if (type.Name.ToLower().Equals("guid")) return (T)(object)new Guid(obj.ToString());
                if (obj is IConvertible) return (T)Convert.ChangeType(obj, type);
                return default(T);
            }
            catch
            {
                return default(T);
            }

        }
        #endregion

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
        /// DataRow转Poco
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
        #endregion

        #region 转换为json
        //TODO 转换为json
        /// <summary>
        /// 转换为json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToJson(object data)
        {
            return "";
        }
        #endregion


        #region 加密，解密
 
  
        /// <summary>
        /// 256位AES加密
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt)
        {
            // 256-AES key    
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// 256位AES解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string toDecrypt)
        {
            // 256-AES key    
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        #endregion

    }
}
