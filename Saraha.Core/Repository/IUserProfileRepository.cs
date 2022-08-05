using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
     public interface IUserProfileRepository
    {
        public List<UserProfile> GetallUserProfile();
        public bool CreateUserProfile(UserProfile userProfile);
        public bool UpdateUserProfile(UserProfile userProfile);
        public bool DeleteUserProfile(int? id);
        public bool IsEmailExist(string email);
        public bool UpdatePremium(int isPremium,int userId);
    }
}
