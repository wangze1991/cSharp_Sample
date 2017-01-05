using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Mvc.Sample.Controllers
{
    [SampleException]
    public class BaseController:Controller
    {


        #region json 扩展方法
        public JsonResult ToJson(bool isSuccess, string msg,JsonRequestBehavior requestBehavior)
        {
            var result = new JsonValue(isSuccess, msg);
            result.JsonRequestBehavior = requestBehavior;
            return result;
        }

        public JsonResult ToJson(bool isSuccess, string msg)
        {
            return ToJson(isSuccess, msg,JsonRequestBehavior.DenyGet);
        }

        public JsonResult ToJson(object data, JsonRequestBehavior requestBehavior)
        {
            var result = new JsonValue(data);
            result.JsonRequestBehavior = requestBehavior;
            return result;
        }
        public JsonResult ToJson(object data)
        {
            return ToJson(data, JsonRequestBehavior.DenyGet);
        }
        #endregion
    }

    public class JsonValue:JsonResult
    {
        private string _dataFormatting;
        public string DateFormatting
        {
            get {
                if (string.IsNullOrWhiteSpace(_dataFormatting))
                    _dataFormatting="yyyy-MM-dd HH:mm:ss";
                return _dataFormatting;
            }
            set {
                _dataFormatting = value;
            }
        }
        public bool isSuccess { get; set; }

        public string msg{get;set;}


        public JsonValue(bool isSuccess, string msg, bool isEasyUiData, object data) {
            this.isSuccess = isSuccess;
            this.msg = msg;
            this.Data = data;
        }


        public JsonValue(bool success, string msg):this(success,msg,false,null)
        {

        }

        public JsonValue(object data)
        {
            this.Data = data;
        }
        /// <summary>Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.</summary>
        /// <param name="context">The context within which the result is executed.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="context" /> parameter is null.</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("当前获取json方式不被允许");
            }
            HttpResponseBase response = context.HttpContext.Response;
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }
            if (this.Data != null)
            {
                response.Write(JsonConvert.SerializeObject(this.Data, Formatting.Indented, new IsoDateTimeConverter { DateTimeFormat = DateFormatting }));
            }
            else
            {
                response.Write(JsonConvert.SerializeObject(new{this.isSuccess,this.msg}));
            }
        }
    }
}