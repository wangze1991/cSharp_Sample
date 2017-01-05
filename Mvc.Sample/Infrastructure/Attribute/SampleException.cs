using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Mvc.Sample
{
   
    public class SampleExceptionAttribute :HandleErrorAttribute
    {
        public static Queue<Exception> QueueException { get; set; }
        static SampleExceptionAttribute() {
            QueueException = new Queue<Exception>();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null) return;
            if (!filterContext.ExceptionHandled)
            {
                QueueException.Enqueue(filterContext.Exception);
                //filterContext.ExceptionHandled = true;
                filterContext.Result=
               filterContext.Result=new RedirectResult("/Home/Error", true);
            }

        }
    }
}