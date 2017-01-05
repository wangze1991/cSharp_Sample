using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Sample.Models;
using Login.Sample.Service;
namespace Login.Sample.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {

        private FormAuthencationService _formService;

        public AccountController() {
            _formService = new FormAuthencationService();
        }


        [HttpGet]
        public ActionResult Login(string returnUrl) {
            ViewBag.returnUrl = returnUrl;
            return View();
        }



        [HttpPost]
        public ActionResult Login(UserViewModel viewModel,string returnUrl)
        {
            if (viewModel.LoginName =="wangze")
            {
                FormAuthencationService.SignIn(viewModel, false);
             if (!string.IsNullOrWhiteSpace(returnUrl))
            {
               return Json(new JsonConsequence(true, "登录成功", returnUrl));
            }
              return Json(new JsonConsequence(true, "登录成功", "/Home/Index"));
            }
            return Json(new JsonConsequence(false,"登录失败"));

        }



        public ActionResult Index()
        {
            return View();
        }
    }
}