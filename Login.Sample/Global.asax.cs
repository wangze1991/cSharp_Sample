using Login.Sample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Login.Sample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal user = HttpContext.Current.User;

            if (user.Identity.IsAuthenticated
                && user.Identity.AuthenticationType == "Forms")
            {

                FormsIdentity formIdentity = user.Identity as FormsIdentity;

                MyFormsPrincipal principal = new MyFormsPrincipal(formIdentity.Ticket);
                HttpContext.Current.User = principal;
                //Thread.CurrentPrincipal = principal;
            }
        }
    }
}
