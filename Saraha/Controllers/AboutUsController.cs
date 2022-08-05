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
        [HttpPost("uploadeimage")]
        public Aboutus uploadeimage()
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
                Aboutus item = new Aboutus();
                item.Imagepath = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
