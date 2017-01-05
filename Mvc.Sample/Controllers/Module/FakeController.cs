using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Sample.Controllers
{
    public class FakeController : Controller
    {
        // GET: Fake
        public ActionResult Index()
        {
            return View();
        }
    }
}