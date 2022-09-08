using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
  public  interface IPostlikeRepository
    {
        public void CreateLike(Postlike post, int userLogin);

        public List<Postlike> GetAllLikes();
        public void DeleteLike(int id);
        public List<Postlike> GetLikeById(int userId);
        public List<PostLikesDTO> GetPostLikes();
        public bool CheckIfLiked(int userId, int postId);

    }
}
