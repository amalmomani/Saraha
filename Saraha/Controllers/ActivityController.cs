using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.Service;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService activityService;
        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Activity>), StatusCodes.Status200OK)]
        public List<Activity> getallActivity()
        {

            return activityService.getallActivity();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Activity), StatusCodes.Status200OK)]
        public bool createActivity([FromBody] Activity activity)
        {
            return activityService.createActivity(activity);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Activity), StatusCodes.Status200OK)]
        public bool UpdateActivity([FromBody] Activity activity)
        {
            return activityService.UpdateActivity(activity);
        }

        [HttpDelete("delete/{id}")]
        public bool deleteActivity(int? id)
        {
            return activityService.deleteActivity(id);
        }














    }
}
