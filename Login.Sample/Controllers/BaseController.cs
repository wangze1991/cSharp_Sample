using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Sample.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class Auth : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //base.HandleUnauthorizedRequest(filterContext);
            if (filterContext.HttpContext.Request.IsAjaxRequest())//如果是ajax请求
            {

            }
            else
            {
                filterContext.Result = new JavaScriptResult() { Script = "alert('登录超时，请重新登录');" };
                //base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}