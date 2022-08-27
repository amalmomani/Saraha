using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
  public class PostlikeService : IPostlikeService
    {
          private readonly IPostlikeRepository repo;
        public PostlikeService(IPostlikeRepository repo)
        {
            this.repo = repo;
        }


        public void CreateLike(Postlike post)

        {
             repo.CreateLike(post);
        }
        public List<Postlike> GetAllLikes()
        {
            return this.repo.GetAllLikes();

        }
        public void DeleteLike(int id)
        {

             repo.DeleteLike(id);

        }

        public List<PostLikesDTO> GetPostLikes()
        {
            return repo.GetPostLikes();
        }
    }
}
