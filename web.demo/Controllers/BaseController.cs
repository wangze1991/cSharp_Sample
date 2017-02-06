using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Web.Demo.Controllers
{
    public class BaseController : Controller
    {

        #region  重写一些json方法
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return base.Json(data, contentType, contentEncoding);
        }

        [NonAction]
        public ActionResult ToJson(object obj,string dateTimeFormat="yyyy-MM-dd"){
            //如果是Ie
            ////IE8 返回不认识application/json，所以只能返回text/html
            if (Request.Browser.Browser.Equals("IE", StringComparison.CurrentCultureIgnoreCase))
            {
                return Content(JsonConvert.SerializeObject(obj,Formatting.Indented,new IsoDateTimeConverter(){ DateTimeFormat=dateTimeFormat}),"text/html",Encoding.UTF8);
            }
            else
            {
                return Json(obj, "application/json", JsonRequestBehavior.AllowGet);
            }
        }
        [NonAction]
        public ActionResult Success(string msg)
        {
            return ToJson(new { isSuccess = true, msg = msg });
        }
        public ActionResult Success(string msg,object data)
        {
            return ToJson(new { isSuccess = true, msg = msg, data =data});
        }
        public ActionResult Success(string msg, object data,object extraData)
        {
            return ToJson(new { isSuccess = true, msg = msg, data = data,extraData=extraData });
        }
        [NonAction]
        public ActionResult Fail(string msg)
        {
            return ToJson(new { isSuccess = false, msg = msg});
        }
        public ActionResult Fail(string msg, object data)
        {
            return ToJson(new { isSuccess = false, msg = msg, data = data });
        }
        public ActionResult Fail(string msg, object data, object extraData)
        {
            return ToJson(new { isSuccess = false, msg = msg, data = data, extraData = extraData });
        }
        #endregion
    }
}