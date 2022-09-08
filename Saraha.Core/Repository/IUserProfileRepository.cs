using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
     public interface IUserProfileRepository
    {
        public List<Userprofile> GetallUserProfile();
        public void CreateUserProfile(RegisterDTO userProfile);
        public void UpdateUserProfile(Userprofile userProfile);
        public void DeleteUserProfile(int? id);
        public bool IsEmailExist(string email);
        public bool UpdatePremium(int isPremium,int userId);
        public int UsersCount();
        public List<Userprofile> GetActiveUsers();
        public List<LoginUsersDTO> GetAllLoginUsers();
        public Userprofile GetUserById(int userId);
        public List<Userprofile> SearchUser(string username, string country, string gender);
        public void GetNotifiactionByUserId(int userId);
        public void UpdateNotIsRead(int userId, int notificationId);




    }
}
