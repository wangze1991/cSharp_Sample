using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Application.Startup))]
namespace Web.Application
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {

        }
    }
}
