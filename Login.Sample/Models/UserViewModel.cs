using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Login.Sample.Models
{
    public class UserViewModel
    {
        public string LoginName { get; set; }

        public string Password { get; set; }
    }

}