using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web.sample.Startup))]
namespace web.sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
