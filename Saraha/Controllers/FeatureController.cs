using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.DTO;
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
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService featureservice;
        public FeatureController(IFeatureService featureservice)
        {
            this.featureservice = featureservice;
        }

        [HttpGet("GetFeatures")]

        public List<Feature> GetFeatures()
        {

            return featureservice.GetAllFeatures();
        }
        [HttpPost("CreateFeature")]
        public void CreateFeature([FromBody] Feature feature)
        {

            featureservice.CreateFeature(feature);
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
                //"C:\\Users\\DELL\\Desktop\\Saraha\\src\\assets"
                var fileName =Guid.NewGuid().ToString()+"_"+Path.GetFileNameWithoutExtension(file.FileName);
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

        [HttpPut("UpdateFeature")]
        public void UpdateFeature([FromBody] Feature feature)
        {
            featureservice.UpdateFeature(feature);
        }

        [HttpDelete("RemoveFeature/{id}")]
        public void DeleteComment(int id)
        {
            featureservice.DeleteFeature(id);
        }
        [HttpGet("GetFeatureSales")]

        public List<FeatureSalesDTO> GetFeatureSales()
        {

            return featureservice.FeatureSales();
        }
        [HttpGet("Chart")]
        public List<Charts> Chart()
        {
            return featureservice.Chart();

        }
        [HttpGet("FeatureName")]
        public List<string> FeatureName()
        {
            return featureservice.FeatureName();
        }
        [HttpGet("FeatureTotalSales")]
        public List<int> FeatureTotalSales()
        {
            return featureservice.FeatureTotalSales();
        }

    }
}
