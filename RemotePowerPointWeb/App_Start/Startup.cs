using Microsoft.Owin;
using Owin;

namespace RemotePowerPointWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
