using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.IO;
namespace Mvc.Sample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

    
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            while (SampleExceptionAttribute.QueueException.Count > 0)
            {
                var exception = SampleExceptionAttribute.QueueException.Dequeue();
                if (!Directory.Exists(Server.MapPath("/Log")))
                {
                    Directory.CreateDirectory(Server.MapPath("/Log"));
                }
                using (StreamWriter sw = new StreamWriter(Server.MapPath("/Log/log.txt"), true))
                {
                    sw.WriteLine(exception.Message);
                }
            }
        }
    }
}
