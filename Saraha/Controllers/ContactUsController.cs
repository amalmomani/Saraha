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
        public List<Contactus> GetAllContactus()
        {

            return ContactUsService.GetAll();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Contactus), StatusCodes.Status200OK)]
        public void CreateContactus([FromBody] Contactus aboutus)
        {
            ContactUsService.Insert(aboutus);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Contactus), StatusCodes.Status200OK)]
        public void UpdateContactus([FromBody] Contactus aboutus)
        {
            ContactUsService.Update(aboutus);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteContactus(int id)
        {
            ContactUsService.Delete(id);
        }

    }
}
