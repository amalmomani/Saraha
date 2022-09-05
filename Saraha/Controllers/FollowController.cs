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
    public class FollowController : ControllerBase
    {
        private readonly IFollowService followService;
        public FollowController(IFollowService followService)
        {
            this.followService = followService;
        }

        [HttpPost]
        public void CreateFollow(Follow follow)
        {
            followService.CreateFollow(follow);
        }

        [HttpDelete("{id}")]
        public void DeleteFollow(int id)
        {
            followService.DeleteFollow(id);
        }

        [HttpGet("DeleteFollowByUser/{userFrom}/{userTo}")]
        public void DeleteFollowByUser(int userFrom, int userTo)
        {
            followService.DeleteFollowByUser(userFrom, userTo);
        }

        [HttpGet]
        public List<Follow> GetAll()
        {
            return followService.GetAll();
        }

        [HttpGet("GetFollowers/{userTo}")]
        public List<Userprofile> GetFollowers(int userTo)
        {
            return followService.GetFollowers(userTo);
        }

        [HttpGet("GetFollowing/{userFrom}")]
        public List<Userprofile> GetFollowing(int userFrom)
        {
            return followService.GetFollowing(userFrom);
        }

        [HttpGet("IsFollow/{userFrom}/{userTo}")]
        public bool IsFollow(int userFrom, int userTo)
        {
            return followService.IsFollow(userFrom, userTo);
        }

        [HttpGet("UpdateBlockStatus/{id}/{isBlock}")]
        public void UpdateBlockStatus(int id, int isBlock)
        {
            followService.UpdateBlockStatus(id, isBlock);
        }
    }
}
