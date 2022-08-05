using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Home> GetAllHome()
        {

            return homeService.GetAll();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Home), StatusCodes.Status200OK)]
        public void CreateHome([FromBody] Home aboutus)
        {
            homeService.Insert(aboutus);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Home), StatusCodes.Status200OK)]
        public void UpdateHome([FromBody] Home aboutus)
        {
            homeService.Update(aboutus);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteHome(int id)
        {
            homeService.Delete(id);
        }
        [HttpPost("uploadeimage")]
        public Home uploadeimage()
        {

            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileContent = ms.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string attachmentFileName = $"(fileName).{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("resc", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
               Home  item = new Home();
                item.Background = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
