﻿using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;

namespace Saraha.Infra.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository repo;
        public ActivityService(IActivityRepository repo)
        {
            this.repo = repo;
        }
        public void CreateActivity(Activity activity)
        {
             repo.CreateActivity(activity);
        }

        public void DeleteActivity(int? id)
        {
             repo.DeleteActivity(id);
        }

        public List<Activity> GetActivityByUserId(int userId)
        {
            return repo.GetActivityByUserId(userId);
        }

        public List<Activity> GetallActivity()
        {
            return repo.GetallActivity();
        }

        public Userprofile GetUserByCommentId(int commentId)
        {
            return repo.GetUserByCommentId(commentId);
        }

        public Userprofile GetUserByFollowId(int followId)
        {
            return repo.GetUserByFollowId(followId);
        }

        public Userprofile GetUserByLikeId(int likeId)
        {
            return repo.GetUserByLikeId(likeId);
        }

        public void UpdateActivity(Activity activity)
        {
             repo.UpdateActivity(activity);
        }
    }
}
