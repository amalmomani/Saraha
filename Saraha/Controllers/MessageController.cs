using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.Service;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;
        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Message>), StatusCodes.Status200OK)]
        public List<Message> GetallMessage()
        {

            return messageService.GetallMessage();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]
        public void CreateMessage([FromBody] Message message)
        {
             messageService.CreateMessage(message);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]
        public void UpdateMessage([FromBody] Message message)
        {
             messageService.UpdateMessage(message);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteMessage(int? id)
        {
             messageService.DeleteMessage(id);
        }











    }
}
