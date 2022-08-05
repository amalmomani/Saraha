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
    public class HomeController : ControllerBase
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Home>), StatusCodes.Status200OK)]
        public List<Home> getallHome()
        {

            return homeService.getall();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Home), StatusCodes.Status200OK)]
        public void createHome([FromBody] Home aboutus)
        {
            homeService.insert(aboutus);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Home), StatusCodes.Status200OK)]
        public void UpdateHome([FromBody] Home aboutus)
        {
            homeService.update(aboutus);
        }

        [HttpDelete("delete/{id}")]
        public void deleteHome(int id)
        {
            homeService.delete(id);
        }

    }
}
