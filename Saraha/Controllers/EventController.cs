using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService EventService;
        public EventController(IEventService EventService)
        {
            this.EventService = EventService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Event>), StatusCodes.Status200OK)]
        public List<Event> GetallEvent()
        {
            return EventService.GetAll();
        }
        [HttpPost]
        public void Create([FromBody] Event a)
        {
            EventService.Insert(a);
        }

        [HttpPut]
        public void Update([FromBody] Event a)
        {
            EventService.Update(a);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            EventService.Delete(id);
        }
    }
}
