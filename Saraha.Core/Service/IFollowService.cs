using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
    public interface IFollowService
    {
        public void CreateFollow(Follow follow);
        public void DeleteFollow(int id);
        public List<Follow> GetAll();
        public void UpdateBlockStatus(int id, int isBlock);
        public List<Userprofile> GetFollowing(int userFrom);
        public List<Userprofile> GetFollowers(int userTo);
        public void DeleteFollowByUser(int userFrom, int userTo);
        public bool IsFollow(int userFrom, int userTo);
    }
}
