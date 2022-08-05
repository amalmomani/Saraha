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
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService AboutUsService;
        public AboutUsController(IAboutUsService AboutUsService)
        {
            this.AboutUsService = AboutUsService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Aboutus>), StatusCodes.Status200OK)]
        public List<Aboutus> GetAllAboutus()
        {

            return AboutUsService.GetAll();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Aboutus), StatusCodes.Status200OK)]
        public void createAboutus([FromBody] Aboutus aboutus)
        {
            AboutUsService.Insert(aboutus);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Aboutus), StatusCodes.Status200OK)]
        public void UpdateAboutus([FromBody] Aboutus aboutus)
        {
            AboutUsService.Update(aboutus);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteAboutus(int id)
        {
            AboutUsService.Delete(id);
        }

    }
}
