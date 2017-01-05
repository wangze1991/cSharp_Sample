using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Providers.Entities;
using Newtonsoft.Json;

namespace Web.Application.Ashx
{
    /// <summary>
    /// SessionSwitch 的摘要说明
    /// </summary>
    public class SessionSwitch : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var actionType = context.Request["action"];
            var result = "";
            if (!string.IsNullOrWhiteSpace(actionType))
            {
                actionType = actionType.ToLower();
                switch (actionType)
                {
                    case "switch":
                        result=Switch(context.Request["userName"]);
                        break;
                    case "getuser":
                        result = GetUser();
                        break;

                }
               context.Response.Write(result);
            }
            else
            {
                context.Response.Write("Hello World"); 
            }

        }

        public string Switch(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                HttpContext.Current.Session["user"] = userName;
            }
            return new JsonData().ToString();
        }

        public string GetUser()
        {
            var user = (HttpContext.Current.Session["user"] ?? "").ToString();
            var model = new JsonData();
            model.isSuccess = true;
            model.data = user;
            return model.ToString();
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


    public class JsonData
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }

        public object data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}