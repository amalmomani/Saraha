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
        [HttpPost("Register")]
        public void CreateUser([FromBody] RegisterDTO userprofile)
        {
            UserProfileService.CreateUserProfile(userprofile);
        }

        [HttpPost("UploadUserImage")]
        public Userprofile UploadUserImage()
        {
            //try
            //{
            //    var file = Request.Form.Files[0];
            //    byte[] fileContent;
            //    using (var ms = new MemoryStream())
            //    {
            //        file.CopyTo(ms);
            //        fileContent = ms.ToArray();
            //    }
            //    var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileNameWithoutExtension(file.FileName);
            //    string attachmentFileName = $"{fileName}.{Path.GetExtension(file.FileName).Replace(".", "")}";
            //    var fullPath = Path.Combine("C:\\Users\\DELL\\Desktop\\Saraha\\src\\assets", attachmentFileName);
            //    using (var stream = new FileStream(fullPath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //    Userprofile item = new Userprofile();
            //    item.Imagepath = attachmentFileName;
            //    return item;
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
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
                var fullPath = Path.Combine("C:\\Users\\DELL\\Desktop\\Saraha\\src\\assets", attachmentFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Userprofile item = new Userprofile();
                item.Imagepath = attachmentFileName;
                return item;
            }
            catch (Exception e)
            {
                return null;
            }

            ///// rawan path "C:\\Users\\Lenovo\\Desktop\\Saraha\\src\\assets"

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
        public int UsersCount()
        {
            return UserProfileService.UsersCount();
        }
        [HttpGet("GetActiveUsers")]
        public List<Userprofile> GetActiveUsers()
        {

            return UserProfileService.GetActiveUsers();
        }

        [HttpGet("GetAllLoginUsers")]
        public List<LoginUsersDTO> GetAllLoginUsers()
        {
            return UserProfileService.GetAllLoginUsers();
        }

        [HttpGet("GetUserById/{userId}")]
        public Userprofile GetUserById(int userId)
        {
            return UserProfileService.GetUserById(userId);
        }

        [HttpGet("SearchUser/{username}/{country}/{gender}")]
        public List<Userprofile> SearchUser(string username, string country, string gender)
        {
            return UserProfileService.SearchUser(username, country, gender);
        }

        [HttpGet("IsEmailExist/{email}")]
        public bool IsEmailExist(string email)
        {
            return UserProfileService.IsEmailExist(email);
        }


        [HttpGet("Notification/{userId}")]
        public void Notification(int userId)
        {
            UserProfileService.GetNotifiactionByUserId(userId);
        }

        [HttpGet("UpdateNot/{userId}/{notificationId}")]
        public void UpdateNot(int userId,int notificationId)
        {
            UserProfileService.UpdateNotIsRead(userId, notificationId);
        }
    }
}

