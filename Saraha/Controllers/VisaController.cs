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
    public class VisaController : ControllerBase
    {
        private readonly IVisaCardServices VisaCardServices;
        public VisaController(IVisaCardServices VisaCardServices)
        {
            this.VisaCardServices = VisaCardServices;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<VisaCard>), StatusCodes.Status200OK)]
        public List<VisaCard> GetallVisa()
        {

            return VisaCardServices.GetallVisa();
        }
        [HttpGet("GetVisa/{card}/{cost}/{userId}/{featureId}")]
        [ProducesResponseType(typeof(List<VisaCard>), StatusCodes.Status200OK)]
        public string GetVisa(string card, int cost, int userId, int featureId)
        {
            return VisaCardServices.GetVisa(card,cost,userId,featureId);
        }

        [HttpPut]
        public void UpdateVisa([FromBody] VisaCard visa, int cost)
        {
            VisaCardServices.UpdateVisa(visa,cost);
        }
    }
}
