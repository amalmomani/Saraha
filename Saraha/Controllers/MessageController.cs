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
        public List<Message> getallMessage()
        {

            return messageService.getallMessage();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]
        public bool createMessage([FromBody] Message message)
        {
            return messageService.createMessage(message);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]
        public bool UpdateMessage([FromBody] Message message)
        {
            return messageService.UpdateMessage(message);
        }

        [HttpDelete("delete/{id}")]
        public bool deleteMessage(int? id)
        {
            return messageService.deleteMessage(id);
        }











    }
}
