using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Login.Sample.Models;
using Newtonsoft.Json;
using System.Web.Mvc;
namespace Login.Sample.Service
{
    public class FormAuthencationService
    {
        public static void SignIn(UserViewModel viewModel,bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();
            var ticket = new FormsAuthenticationTicket(1,
                viewModel.LoginName, 
                now, 
                now.Add(FormsAuthentication.Timeout), 
                createPersistentCookie,
                JsonConvert.SerializeObject(viewModel),
                FormsAuthentication.FormsCookiePath);
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
            //nop源码中没有这一句，务必保证webconfig中的认证是form的。
            //FormsAuthentication.SetAuthCookie(user.Username, createPersistentCookie);
        }


        /// <summary>
        /// 注销
        /// </summary>
        public static void SignOut() {
            FormsAuthentication.SignOut();
        }

        public static string GetUserData() {
            if (HttpContext.Current == null) throw new ArgumentNullException("context");
            if (!HttpContext.Current.Request.IsAuthenticated)  throw new Exception("对不起，您还没有登录");
            var identity = (HttpContext.Current.User.Identity as CustomIdentity);
            if(string.IsNullOrEmpty(identity.UserData)) throw new Exception("没有存放数据");
            return identity.UserData;
        
        }
    }
}