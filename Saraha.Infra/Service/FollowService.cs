using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository followRepository;

        public FollowService (IFollowRepository followRepository)
        {
            this.followRepository = followRepository;
        }
        public void CreateFollow(Follow follow)
        {
             followRepository.CreateFollow(follow);
        }

        public void DeleteFollow(int id)
        {
            followRepository.DeleteFollow(id);
        }

        public void DeleteFollowByUser(int userFrom, int userTo)
        {
            followRepository.DeleteFollowByUser(userFrom,userTo);
        }

        public List<Follow> GetAll()
        {
            return followRepository.GetAll();
        }

        public List<Userprofile> GetFollowers(int userTo)
        {
            return followRepository.GetFollowers(userTo);
        }

        public List<Userprofile> GetFollowing(int userFrom)
        {
            return followRepository.GetFollowing(userFrom);
        }

        public bool IsFollow(int userFrom, int userTo)
        {
            return followRepository.IsFollow(userFrom, userTo);
        }

        public void UpdateBlockStatus(int id, int isBlock)
        {
             followRepository.UpdateBlockStatus(id, isBlock);
        }
    }
}
