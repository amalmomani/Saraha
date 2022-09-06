using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageeController : ControllerBase
    {
        private int count = 0 ;
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageeController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("test/{message}")]
        public async Task<IActionResult> SendMessage(string message)
        {
            count = count +1 ;
           
            await _hubContext.Clients.All.SendAsync("waed",message);
            
                await _hubContext.Clients.All.SendAsync("www", count);

            return Ok();
        }
    }
}
