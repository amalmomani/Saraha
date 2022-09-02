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
        public Aboutus GetAboutus()
        {

            return AboutUsService.GetAboutUs();
        }

     
        [HttpPut]
        [ProducesResponseType(typeof(Aboutus), StatusCodes.Status200OK)]
        public void UpdateAboutus([FromBody] Aboutus aboutus)
        {
            AboutUsService.UpdateAboutUs(aboutus);
        }

        #region Upload Image Methods 
        [HttpPost("UploadeImagePath")]
        public Aboutus UploadeImagePath()
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
                var fileName = Guid.NewGuid() + "_" + Path.GetFileNameWithoutExtension(file.FileName);
                string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("C:\\Users\\C_ROAD\\Desktop\\SARAHA-Final\\Saraha\\src\\assets", attachmentFileName);
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


        [HttpPost("UploadeFeature1Image")]
        public Aboutus UploadeFeature1Image()
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
                var fileName = Guid.NewGuid() + "_" + Path.GetFileNameWithoutExtension(file.FileName);
                string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("C:\\Users\\Amal\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Aboutus item = new Aboutus();
                item.Feature1_Image = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
       
        
        [HttpPost("UploadeFeature2Image")]
        public Aboutus UploadeFeature2Image()
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
                var fileName = Guid.NewGuid() + "_" + Path.GetFileNameWithoutExtension(file.FileName);
                string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("C:\\Users\\Amal\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Aboutus item = new Aboutus();
                item.Feature2_Image = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
       
        
        [HttpPost("UploadeFeature3Image")]
        public Aboutus UploadeFeature3Image()
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
                var fileName = Guid.NewGuid() + "_" + Path.GetFileNameWithoutExtension(file.FileName);
                string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("C:\\Users\\Amal\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Aboutus item = new Aboutus();
                item.Feature3_Image = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
