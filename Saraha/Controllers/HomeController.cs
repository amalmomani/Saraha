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
        public Home GetHome()
        {

            return homeService.GetHome();
        }
       

        [HttpPut]
        [ProducesResponseType(typeof(Home), StatusCodes.Status200OK)]
        public void UpdateHome([FromBody] Home aboutus)
        {
            homeService.UpdateHome(aboutus);
        }

        [HttpPost("UploadLogo")]
        public Home UploadLogo()
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
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home item = new Home();
                item.Logo = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost("UploadSlider1")]
        public Home UploadSlider1()
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
                /* string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets", attachmentFileName);*/
                
                var fileName = Guid.NewGuid() +"_"+ Path.GetFileNameWithoutExtension(file.FileName);
                string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
               Home  item = new Home();
                item.Slider1 = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
         
        [HttpPost("UploadSlider2")]
        public Home UploadSlider2()
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
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home item = new Home();
                item.Slider2 = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadMemberImage1")]
        public Home UploadMemberImage1()
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
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home item = new Home();
                item.Member1_Image = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadMemberImage2")]
        public Home UploadMemberImage2()
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
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home item = new Home();
                item.Member2_Image = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadMemberImage3")]
        public Home UploadMemberImage3()
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
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home item = new Home();
                item.Member3_Image = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadMemberImage4")]
        public Home UploadMemberImage4()
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
                var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Home item = new Home();
                item.Member4_Image = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
