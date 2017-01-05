using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using Mvc.Sample.Models;
using Utils;
using Utils.Office;
namespace Mvc.Sample.Controllers
{
    public class HomeController : BaseController
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetJson(int page = 1, int rows = 10)
        {
            var path = HttpContext.Server.MapPath("~/Data/datagrid_data1.json");
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadToEnd();
                return Content(str, "application/json");
            }
        }

        public ActionResult JqueryTest()
        {
            return View();
        }

        public void Download()
        {
            Exporter.Instance().SetExport(new XlsExport()).SetDataSource(new ApiData()).SetHead("报表标题").Export().DownLoad();
        }

        public ActionResult ProgressBar()
        {
            return View();
        }

        public async void CallProgressAsync(string pid)
        {
            var progress = new Progress<double>(x => { HttpContext.Cache.Insert("progress", x); });
            progress.ProgressChanged += Progress_ProgressChanged;
            await ProgressAsync(pid, progress);
        }

        async Task ProgressAsync(string pid, IProgress<double> progress)
        {
            double percent = 0;
            while (percent != 100)
            {

                await Task.Delay(1000);
                percent++;
                //HttpContext.Cache.Insert(pid, percent);
                progress.Report(percent);
            }
        }

        private void Progress_ProgressChanged(object sender, double e)
        {
            HttpContext.Cache.Insert("progress", e);
        }
        public JsonResult GetProgressState(string pid)
        {
            var number = double.Parse((HttpContext.Cache.Get("progress") ?? 0).ToString());
            //HttpContext.Cache.Remove("progress");
            return Json(number, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Index(List<Student> list, List<Student> stu)
        {
            var aa = Request.Form["aa"];
            Console.WriteLine(list);
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult StreamDemo()
        {
           // var str = "";
            string path = Server.MapPath("~/Files/Test.txt");
            StringBuilder sb = new StringBuilder();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var byteBuffer = new byte[1024];
                var dataLength = fs.Length;
                fs.Seek(0, SeekOrigin.Begin);
                while (dataLength > 0)
                {
                    dataLength -= fs.Read(byteBuffer, 0, byteBuffer.Length);
                    sb.Append(Encoding.Default.GetString(byteBuffer));

                }
                return View((object)sb.ToString());
            }
            //using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            //{
            //    str = sr.ReadToEnd();
            //    return View((object)str);
            //}

        }

        public ActionResult SessionDemo() {
            var act = new ControllerActivate();
            var result = act.GetData();
            return View();
        }
        public void RegisterSession() {
            Session.Timeout = 20;
            Session["User"] = "我是session";

        }
        public JsonResult GetSession(string url) { 
            IDictionary<string,string> paramters=new Dictionary<string,string>();
            paramters.Add("timeStamp",DateTime.Now.Ticks.ToString());
            var cookie = Request.Headers["Cookie"];
            var str= HttpHelper.GetPostHtml(url, cookie,paramters );
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        [Auth]
        public string SessionTest(string timeStamp="")
        {
            return timeStamp;
        }
        public string TestResponse(string timeStamp = "空")
        {
            return  timeStamp;
        }
        [HttpGet]
        public ActionResult ModelBindTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ModelBindTest(string[] a)
        {
            var b = a;
            return Json(b);
        }

    }
}