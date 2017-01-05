using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Threading;
namespace 模板模式
{
    public abstract class Poster
    {
        public EmailContent Content { get; set; }

        protected Poster() {
            this.Content = new EmailContent();
            Console.WriteLine("父类 无参初始化");
        }

        protected Poster(string address)
        {
            this.Content = new EmailContent();
            Content.EmailAddress = address;
            Console.WriteLine("父类有参初始化");
        }
        private readonly static  MailMessage _maimessage;

         static Poster() {
             _maimessage = new MailMessage();
             _maimessage.From = new MailAddress(ConfigureHelper.GetValueWithKey("post_email"));
        }
        /// <summary>
        /// 发送邮件基类
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Task SendEmailBase(EmailContent content) {
            _maimessage.To.Add(content.EmailAddress);
            _maimessage.Subject =content.Subject;//主题
            _maimessage.Body = content.Body;//正文
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigureHelper.GetValueWithKey("smtp_host");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(ConfigureHelper.GetValueWithKey("post_email"), ConfigureHelper.GetValueWithKey("host"));
            //smtp.SendMailAsync(_maimessage);
           return Task.Run(()=> {
               Thread.Sleep(1000);
                Console.WriteLine("发送成功");
                Console.WriteLine("收件人:{0}",content.EmailAddress);
                Console.WriteLine("主题:{0}",content.Subject);
                Console.WriteLine("收件内容:{0}",content.Body);
            });

        }
        public static Task SendEmail(Poster poster) {
            var content = poster.GetEmailReciver();
            return Poster.SendEmailBase(content);
        }
        /// <summary>
        /// 获取收件人相关信息
        /// </summary>
        /// <returns></returns>
        public abstract EmailContent GetEmailReciver();
    }
}
