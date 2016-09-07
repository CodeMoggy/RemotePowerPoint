using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotePowerPointWeb.Hubs
{
    [HubName("slider")]
    public class SliderHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.Caller.connected(Context.ConnectionId);
            return base.OnConnected();
        }

    }
}
