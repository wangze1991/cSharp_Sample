using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Sample.Controllers;
namespace Mvc.Sample
{
    public class AuthAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUser =httpContext.Session["User"];
            if (currentUser == null) return false;
            return true && base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { isSuccess = false, msg = "当前登录已经失效，请重新登录" }
                };
                return;
            }
            else
            {
                filterContext.Result = new HomeController().Index();
            }
            //base.HandleUnauthorizedRequest(filterContext);


        }
    }
}