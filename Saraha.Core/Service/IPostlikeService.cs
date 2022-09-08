using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
 public interface IPostlikeService
    {

        public void CreateLike(Postlike post, int userLogin);

        public List<Postlike> GetAllLikes();
        public void DeleteLike(int id);
        public List<PostLikesDTO> GetPostLikes();
        public List<Postlike> GetLikeById(int userId);
        public bool CheckIfLiked(int userId, int postId);
        public void DeleteLikeByUserPostId(int userId, int postId);

    }
}
