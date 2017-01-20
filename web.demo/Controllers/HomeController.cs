using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Demo.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetIeJson()
        {

            return ToJson(new { a = 1, b = 2 });

        }

        public ActionResult TestValid() {

            return View();
        }
    }
}