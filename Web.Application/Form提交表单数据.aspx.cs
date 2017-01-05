using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Application
{
    public partial class Form提交表单数据 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                var form = this.Request.Form;
            using (Stream reqStream = this.Request.InputStream)
            {
                //byte[] buffer = new byte[reqStream.Length];
                //reqStream.Read(buffer, 0,(int)reqStream.Length);
                TextReader txReader=new StreamReader(reqStream);
                string str = txReader.ReadToEnd();
                txReader.Close();
            }
        }
    }
}