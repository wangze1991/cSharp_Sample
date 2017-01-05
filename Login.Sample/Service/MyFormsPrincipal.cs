using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Login.Sample.Service
{
    public class MyFormsPrincipal : IPrincipal
    {
        private CustomIdentity _identity;
        public MyFormsPrincipal(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            _identity = new CustomIdentity(ticket);
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}