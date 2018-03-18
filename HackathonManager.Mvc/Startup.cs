using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HackathonManager.Mvc.Startup))]
namespace HackathonManager.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
