using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Application
{
    public partial class Cookie练习 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["name"];
            if (cookie==null)
            {
                cookie=new HttpCookie("name");
                cookie.Value = DateTime.Now.ToString();
                cookie.Expires = DateTime.Now.AddMinutes(5);
                Response.AppendCookie(cookie);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["name"]))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + Request["name"] + "')", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert(没有值)", true);
            }
        }
    }
}