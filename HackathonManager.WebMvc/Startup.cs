using Microsoft.Owin;
using Owin;
using HackathonManager;

namespace HackathonManager.WebMvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}