using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Sample.Models
{
    public enum UserLoginResult
    {
        Success,
        UserNotExist,
        PasswordWrong
    }
}