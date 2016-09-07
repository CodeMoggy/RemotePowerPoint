using RemotePowerPointWeb.Hubs;
using RemotePowerPointWeb.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RemotePowerPointWeb.Controllers
{
    // revisit this line of code if put into production
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SlidesController : SlidesControllerWithHub<SliderHub>
    {
        [HttpPost]
        [Route("api/Slides/Next")]
        public async Task Next([FromBody] SliderClient client)
        {
            await Hub.Clients.Client(client.ClientId).next();
        }

        [HttpPost]
        [Route("api/Slides/Previous")]
        public async Task Previous([FromBody] SliderClient client)
        {
            await Hub.Clients.Client(client.ClientId).previous();
        }

        [HttpPost]
        [Route("api/Slides/First")]
        public async Task Start([FromBody] SliderClient client)
        {
            await Hub.Clients.Client(client.ClientId).first();
        }

        [HttpPost]
        [Route("api/Slides/Last")]
        public async Task End([FromBody] SliderClient client)
        {
            await Hub.Clients.Client(client.ClientId).last();
        }
    }
}
