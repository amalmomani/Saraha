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

        [HttpPut]
        public void UpdateVisa([FromBody] VisaCard visa)
        {
            VisaCardServices.UpdateVisa(visa);
        }
    }
}
