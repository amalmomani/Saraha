using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
     public interface IUserProfileRepository
    {
        public List<Userprofile> GetallUserProfile();
        public bool CreateUserProfile(Userprofile userProfile);
        public bool UpdateUserProfile(Userprofile userProfile);
        public bool DeleteUserProfile(int? id);
        public bool IsEmailExist(string email);
        public bool UpdatePremium(int isPremium,int userId);
    }
}
