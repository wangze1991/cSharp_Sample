using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalR.Sample.Startup))]

namespace SignalR.Sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}