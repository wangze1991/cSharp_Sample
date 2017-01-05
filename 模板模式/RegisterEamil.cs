using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模板模式
{
    public class RegisterEamil:Poster
    {

        public RegisterEamil(string address): base(address)
        {

        }

        public override EmailContent GetEmailReciver()
        {
            this.Content.Body = "这是注册成功的邮件内容";
            this.Content.Subject = "这是注册成功的主题";
            return this.Content;
        }
    }
}
