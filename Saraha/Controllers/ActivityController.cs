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
        public List<Activity> GetallActivity()
        {

            return activityService.GetallActivity();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Activity), StatusCodes.Status200OK)]
        public void CreateActivity([FromBody] Activity activity)
        {
             activityService.CreateActivity(activity);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Activity), StatusCodes.Status200OK)]
        public void UpdateActivity([FromBody] Activity activity)
        {
             activityService.UpdateActivity(activity);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteActivity(int? id)
        {
             activityService.DeleteActivity(id);
        }

        [HttpGet("GetActivityByUserId/{userId}")]
        public List<Activity> GetActivityByUserId(int userId)
        {
            return activityService.GetActivityByUserId(userId);
        }

    }
}
