using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebApi.SelfHost.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080"); //配置主机

            config.Routes.MapHttpRoute(    //配置路由
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config)) //监听HTTP
            {
                server.OpenAsync().Wait(); //开启来自客户端的请求
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
