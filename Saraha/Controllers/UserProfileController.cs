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
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService UserProfileService;
        public UserProfileController(IUserProfileService UserProfileService)
        {
            this.UserProfileService = UserProfileService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Userprofile>), StatusCodes.Status200OK)]
        public List<Userprofile> GetAllUsers()
        {

            return UserProfileService.GetallUserProfile();
        }
        [HttpPost]
        [ProducesResponseType(typeof(Userprofile), StatusCodes.Status200OK)]
        public void CreateUser([FromBody] Userprofile userprofile)
        {
            UserProfileService.CreateUserProfile(userprofile);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Userprofile), StatusCodes.Status200OK)]
        public void UpdateUser([FromBody] Userprofile userprofile)
        {
            UserProfileService.UpdateUserProfile(userprofile);
        }

        [HttpDelete("delete/{id}")]
        public void DeleteUser(int id)
        {
            UserProfileService.DeleteUserProfile(id);
        }

        [HttpGet("UserCount")]
        public int UsersCount ()
        {
            return UserProfileService.UsersCount();
        }
        [HttpGet("GetActiveUsers")]
        public List<Userprofile> GetActiveUsers()
        {

            return UserProfileService.GetActiveUsers();
        }
    }
}
