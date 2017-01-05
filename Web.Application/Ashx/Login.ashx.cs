using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Web.Application.Ashx
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler,IRequiresSessionState
    {
        public string Action
        {
            get { return HttpContext.Current.Request["action"]; }
        }

        public string Email {
            get {return HttpContext.Current.Request["name"]; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (Action)
            {
                case"checkEmail":
                    context.Response.Write(CheckEmail(Email));
                    break;
            }
        }

        public string CheckEmail(string email)
        {
            string[] emailList = {"595702583@qq.com","123@qq.com"};
            bool isExist = emailList.Any(x => x == email);
            return isExist ? "1" : "-1";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}