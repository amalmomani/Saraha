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
    public class ContactUsController : ControllerBase
    {
        private readonly IContactusService ContactUsService;
        public ContactUsController(IContactusService ContactUsService)
        {
            this.ContactUsService = ContactUsService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Contactus>), StatusCodes.Status200OK)]
        public List<Contactus> getallContactus()
        {

            return ContactUsService.getall();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Contactus), StatusCodes.Status200OK)]
        public void createContactus([FromBody] Contactus aboutus)
        {
            ContactUsService.insert(aboutus);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Contactus), StatusCodes.Status200OK)]
        public void UpdateContactus([FromBody] Contactus aboutus)
        {
            ContactUsService.update(aboutus);
        }

        [HttpDelete("delete/{id}")]
        public void deleteContactus(int id)
        {
            ContactUsService.delete(id);
        }

    }
}
