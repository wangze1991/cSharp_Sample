using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Web.Application.Ashx
{
    /// <summary>
    /// Template 的摘要说明
    /// </summary>
    public class Template : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            Thread.Sleep(2000);
            string[] template={"<form>",
            "<label>用户名</label>",
            "<input type='text' value=''/>",
            "<label>密码<label>",
            "<input type='text' value=''/>",
            "<input type='submit' value='提交' id='btn-submit'/>", 
            "</form>"};
            context.Response.Write(string.Join("",template));
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