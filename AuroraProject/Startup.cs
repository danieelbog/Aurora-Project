using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuroraProject.Startup))]
namespace AuroraProject
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
