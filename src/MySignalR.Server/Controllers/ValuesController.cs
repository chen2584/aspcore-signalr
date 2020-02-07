using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MySignalR.Hubs;

namespace MySignalR.Server.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        readonly IHubContext<ChatHub> _chatHub;
        public ValuesController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _chatHub.Clients.All.SendAsync("ReceiveMessage", "Chen", "Hello from Values Api");
            return Ok("Sended message to ChatHub");
        }
    }
}