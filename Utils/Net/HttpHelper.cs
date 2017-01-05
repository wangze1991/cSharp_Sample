using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace Utils
{
    public class HttpHelper
    {
        private static string _contentType = "application/x-www-form-urlencoded";

        private static int _timeOut = 5 * 1000;

        private const string _accept = "*/*";

        private const string _userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";

        public static string GetHtml(string url, bool isPost, string strCookie, string postString)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                StringBuilder builderHtml =new StringBuilder();
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.DefaultConnectionLimit = 100;//设置并发连接数限制上额
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = isPost ? "POST" : "GET";
                request.ContentType = _contentType;
                request.ServicePoint.Expect100Continue = false;
                //request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                //request.Timeout = _timeOut;
                request.Accept = _accept;
                request.UserAgent = _userAgent;
           
                if (!strCookie.IsNullOrEmpty())
                {
                    //request.Host = new Uri(url).Host;
                    //request.Headers.Add("Cookie", strCookie);
                    //var cookieArray = strCookie.Split(';');
                    //if (cookieArray.Length >= 0)
                    //{
                    //    cookieArray.ToList().ForEach(x =>
                    //    {
                    //        request.CookieContainer.SetCookies(new Uri(url), x);
                    //    });
                    //}
                    request.CookieContainer = new CookieContainer();
                    var collection = strCokAddCol(strCookie, url);
                    request.CookieContainer.Add(collection);
                }
                if (isPost && !postString.IsNullOrEmpty())
                {
                    byte[] byteRequest = Encoding.UTF8.GetBytes(postString);
                    Stream stream = request.GetRequestStream();
                    stream.Write(byteRequest, 0, byteRequest.Length);
                    stream.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK) {
                    throw new Exception("网络连接失败");
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    //using (var ms = StreamToMemoryStream(responseStream))
                   //{
                    StreamReader sr = new StreamReader(responseStream, Encoding.UTF8);
                        int bufferrLength = 1024;
                        char[] buffer = new char[1024];
                        int count = 0;
                        while ((count= sr.Read(buffer, 0, bufferrLength))>0)
                        {               
                            builderHtml.AppendLine(buffer.Aggregate("", (total, next) => total + next));
                        }
                        sr.Close();
                   ///}
                }

              
                return builderHtml.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
            finally
            {
                if (request != null)
                    request.Abort();
                if (response != null)
                    response.Close();
            }

        }

       private static  MemoryStream StreamToMemoryStream(Stream instream)
        {
            MemoryStream outstream = new MemoryStream();
            const int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int count = 0;
            while ((count = instream.Read(buffer, 0, bufferLen)) > 0)
            {
                outstream.Write(buffer, 0, count);
            }
            return outstream;
        }

        #region 重载

        #region get
        public static string GetHtml(string url)
        {
            return HttpHelper.GetHtml(url, false, null, null);
        }
        public static string GetHtml(string url, string strCookie)
        {
            return HttpHelper.GetHtml(url, true, strCookie, null);
        }
        #endregion

        #region post
        public static string GetPostHtml(string url, string postString)
        {
            return HttpHelper.GetHtml(url, true, null, postString);
        }

        public static string GetPostHtml(string url, string strCookie, string postString)
        {
            return HttpHelper.GetHtml(url, true, strCookie, postString);
        }
        public static string GetPostHtml(string url, string strCookie, IDictionary<string, string> postDic)
        {
            return HttpHelper.GetHtml(url, true, strCookie, HttpHelper.CoventPostParamToString(postDic));
        }

        #endregion

        #endregion
        #region 异步

        public async Task<string> GetStringAsync(string url)
        {
            HttpClient hc = new HttpClient();
            //hc.DefaultRequestHeaders.Add("UserAgent", "contact@cnblogs.com");
            return await hc.GetStringAsync(url);
        }

        #endregion

        #region 下载
        /// <summary>
        /// 使用OutputStream.Write分块下载文件  
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteFileBlock(string filePath)
        {
            filePath = HttpContext.Current.Server.MapPath(filePath);
            if (!File.Exists(filePath)) return;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var fileName = Path.GetFileName(filePath);
                HttpHelper.DownLoad(fs, fileName, ContentType.UnKnown);
            }
        }

        /// <summary>
        /// 分段下载
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="fileName">文件名称(带后缀)</param>
        /// <param name="contentType">返回类型</param>
        public static void DownLoad(Stream stream, string fileName, string contentType)
        {
            //指定块大小   
            long chunkSize = 4096;
            //建立一个4K的缓冲区   
            byte[] buffer = new byte[chunkSize];
            //剩余的字节数   
            long dataToRead = 0;
            try
            {
                dataToRead = stream.Length;
                stream.Seek(0, SeekOrigin.Begin);
                //添加Http头   
                HttpContext.Current.Response.ContentType = contentType;
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachement;filename=" + HttpContext.Current.Server.UrlEncode(fileName));
                HttpContext.Current.Response.AddHeader("Content-Length", dataToRead.ToString());
                if (HttpContext.Current.Request.ServerVariables["http_user_agent"].ToLower().IndexOf("firefox") != -1)
                {
                    fileName = "\"" + fileName + "\"";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachement;filename=" + fileName);
                }
                else
                {
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachement;filename=" + HttpContext.Current.Server.UrlEncode(fileName));
                } 
                while (dataToRead > 0)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        int length = stream.Read(buffer, 0, Convert.ToInt32(chunkSize));
                        if (length == 0) throw new Exception("导出出错了");
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.Clear();
                        dataToRead -= length;
                    }
                    else
                    {
                        //防止client失去连接   
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error:" + ex.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                HttpContext.Current.Response.Close();
            }

        }

        public static void DownloadExcel(Stream stream, string fileName)
        {
            HttpHelper.DownLoad(stream, fileName, ContentType.Excel);
        }
        public static void DownloadWord(Stream stream, string fileName)
        {
            HttpHelper.DownLoad(stream, fileName, ContentType.Word);
        }
        #endregion

        #region 公共方法

        public static string CoventPostParamToString(IDictionary<string, string> postDict)
        {
            if (null == postDict) return null;
            StringBuilder buffer = new StringBuilder();
            foreach (var dic in postDict)
            {
                buffer.AppendFormat("&{0}={1}", dic.Key, dic.Value);
            }
            return buffer.ToString().TrimStart('&');
        }

        /// <summary>
        /// 一个到多个Cookie的字符串添加到CookieCollection集合中
        /// </summary>
        /// <param name="s">Cookie的字符串</param>
        /// <param name="defaultDomain">站点主机部分</param>
        public static CookieCollection strCokAddCol(string s, string defaultDomain)
        {
            CookieCollection cc = new CookieCollection();
            if (string.IsNullOrEmpty(s) || s.Length < 5 || s.IndexOf("=") < 0) return cc;
            if (string.IsNullOrEmpty(defaultDomain) || defaultDomain.Length < 5) return cc;
            s.TrimEnd(new char[] { ';' }).Trim();
            Uri urI = new Uri(defaultDomain);
            defaultDomain = urI.Host.ToString();
            //用软件截取的cookie会带有expires，要把它替换掉
            if (s.IndexOf("expires=") >= 0)
            {
                s = replace(s, @"expires=[\w\s,-:]*GMT[;]?", "");
            }
            //只有一个cookie直接添加【isGood代码】
            if (s.IndexOf(";") < 0)
            {
                System.Net.Cookie c = new System.Net.Cookie(s.Substring(0, s.IndexOf("=")), s.Substring(s.IndexOf("=") + 1));
                c.Domain = defaultDomain;
                cc.Add(c);
                return cc;
            }
            //不同站点与不同路径一般是以英文道号分别
            if (s.IndexOf(",") > 0)
            {
                s.TrimEnd(new char[] { ',' }).Trim();
                foreach (string s2 in s.Split(','))
                {
                    cc = strCokAddCol(s2, defaultDomain, cc);
                }
                return cc;
            }
            else //同站点与同路径,不同.Name与.Value【isGood代码】
            {
                return strCokAddCol(s, defaultDomain, cc);
            }
        }
        //添加到CookieCollection集合部分
        private static CookieCollection strCokAddCol(string s, string defaultDomain, CookieCollection cc)
        {
            try
            {
                s.TrimEnd(new char[] { ';' }).Trim();
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                foreach (string s2 in s.Split(';'))
                {
                    string s3 = s2.Trim();
                    if (s3.IndexOf("=") > 0)
                    {
                        string[] s4 = s3.Split('=');
                        hs.Add(s4[0].Trim(), s4[1].Trim());
                    }
                }
                string defaultPath = "/";
                foreach (object Key in hs.Keys)
                {
                    if (Key.ToString().ToLower() == "path")
                    {
                        defaultPath = hs[Key].ToString();
                    }
                    else if (Key.ToString().ToLower() == "domain")
                    {
                        defaultDomain = hs[Key].ToString();
                    }
                }
                foreach (object Key in hs.Keys)
                {
                    if (!string.IsNullOrEmpty(Key.ToString()) && !string.IsNullOrEmpty(hs[Key].ToString()))
                    {
                        if (Key.ToString().ToLower() != "path" && Key.ToString().ToLower() != "domain")
                        {
                            Cookie c = new Cookie();
                            c.Name = Key.ToString();
                            c.Value = hs[Key].ToString();
                            c.Path = defaultPath;
                            c.Domain = defaultDomain;
                            cc.Add(c);
                        }
                    }
                }
            }
            catch
            {

            }
            return cc;
        }

        /// <summary>
        /// 替换字符
        /// </summary>
        /// <param name="strSource">来源</param>
        /// <param name="strRegex">表达式</param>
        /// <param name="strReplace">取代</param>
        public static string replace(string strSource, string strRegex, string strReplace)
        {
            try
            {
                Regex r;
                r = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                string s = r.Replace(strSource, strReplace);
                return s;
            }
            catch
            {
                return strSource;
            }
        }
        #endregion
    }


    public class ContentType
    {
        public static string Excel
        {
            get
            {
                return "application/vnd.ms-excel";
            }
        }
        public static string Word
        {
            get
            {
                return "application/msword";
            }
        }
        public static string UnKnown
        {
            get
            {
                return "application/octet-stream";
            }
        }
    }
}
