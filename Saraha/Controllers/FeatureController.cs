using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
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

    }
}
