using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
    public interface IUserProfileService
    {
        public List<Userprofile> GetallUserProfile();
        public void CreateUserProfile(Userprofile userProfile);
        public void UpdateUserProfile(Userprofile userProfile);
        public void DeleteUserProfile(int? id);
        public bool IsEmailExist(string email);
        public bool UpdatePremium(int isPremium, int userId);
        public int UsersCount();
    }
}
