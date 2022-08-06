﻿using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository repo;
        public UserProfileService(IUserProfileRepository repo)
        {
            this.repo = repo;
        }
        public void CreateUserProfile(Userprofile userProfile)
        {
            repo.CreateUserProfile(userProfile);
        }

        public void DeleteUserProfile(int? id)
        {
            repo.DeleteUserProfile(id);
        }

        public List<Userprofile> GetallUserProfile()
        {
            return GetallUserProfile();
        }

        public bool IsEmailExist(string email)
        {
            return repo.IsEmailExist(email);
        }

        public bool UpdatePremium(int isPremium, int userId)
        {
            return repo.UpdatePremium(isPremium,userId);
        }

        public void UpdateUserProfile(Userprofile userProfile)
        {
            repo.UpdateUserProfile(userProfile);
        }

        public int UsersCount()
        {
            return repo.UsersCount();
        }
    }
}