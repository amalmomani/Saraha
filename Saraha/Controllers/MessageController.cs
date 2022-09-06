using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.DTO;
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


        [HttpGet("UserMessages")]
        [ProducesResponseType(typeof(List<UserMessage>), StatusCodes.Status200OK)]
        public List<UserMessage> GetUserMessages()
        {

            return messageService.GetUserMessage();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]
        public void CreateMessage([FromBody] Message message)
        {
             messageService.CreateMessage(message, 1);
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

        [HttpGet("GetUserMessageById/{userId}")]
        public List<UserMessage> GetUserMessageById(int userId)
        {
            return messageService.GetUserMessageById(userId);
        }
        [HttpGet("messagecount/{userId}")]
        public List<Message> GetUserMessageByIdcount(int userId)
        {
            return messageService.GetUserMessageByIdcount(userId);
        }
    }
}
