using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Sample.Controllers
{
 
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test() {
            var a = Request.QueryString["a"];

            var b = Request.QueryString["A"];

            var c = Request.Form["aNumber"];

            var d = Request.Form["ANumber"];

            var e = Request["aNumber"];

            var f = Request["ANumber"];
            return View("Index");
        
        }
    }
}