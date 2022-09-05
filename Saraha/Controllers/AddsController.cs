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
    public class AddsController : ControllerBase
    {
        private readonly IAddsService AddsService;
        public AddsController(IAddsService AddsService)
        {
            this.AddsService = AddsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Adds>), StatusCodes.Status200OK)]
        public List<Adds> GetallAdds()
        {
            return AddsService.GetAll();
        }
        [HttpPost]
        public void Create([FromBody] Adds a)
        {
            AddsService.Insert(a);
        }

        [HttpPut]
        public void Update([FromBody] Adds a)
        {
            AddsService.Update(a);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            AddsService.Delete(id);
        }
        [HttpGet("GetAddsById")]

        public Adds GetAddsById()
        {
            List<Adds> a = new List<Adds>();
            a=  AddsService.GetAll();
            List<int> idd = new List<int>();

            foreach (var i in a)
            {
                idd.Add(i.id);
            }
            var random = new Random();

            int index = random.Next(idd.Count);
            int ad = idd[index];

            var add = a.Where(a => a.id == ad).FirstOrDefault();
            return add;
        }

        [HttpPost("CreateImagePath")]
        public Feature CreateImagePath()
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
                //C:\\Users\\DELL\\Desktop\\Saraha11\\src\\assets  saja path
                var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileNameWithoutExtension(file.FileName);
                string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
                var fullPath = Path.Combine("C:\\Users\\Amal\\Desktop\\Saraha\\src\\assets", attachmentFileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Feature item = new Feature();
                item.ImagePath = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
