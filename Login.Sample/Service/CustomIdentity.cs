using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Login.Sample.Service
{
    public class CustomIdentity:IIdentity
    {
        private FormsAuthenticationTicket _ticket;

        public string UserData { get; private set; }

        public CustomIdentity(FormsAuthenticationTicket ticket)
        {
            _ticket = ticket;
            UserData = ticket.UserData;
        }


        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return _ticket.Name; }
        }
    }
}