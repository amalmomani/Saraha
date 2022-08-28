using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository repo;
        public PostService(IPostRepository repo)
        {
            this.repo = repo;
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<Post> GetAll()
        {
            return repo.GetAll();
        }public List<PostUserComment> PostUserComments()
        {
            return repo.PostUserComments();
        }

        public void Insert(Post post)
        {
            repo.Insert(post);
        }

        public void PinPost(int id, int isPin)
        {
            repo.PinPost(id , isPin);
        }

        public void Update(Post post)
        {
            repo.Update(post);
        }
        public List<PostFullDataDTO> GetPostByUserId(int userId)
        {
            return repo.GetPostByUserId(userId);


        }
        public List<PostLikesDTO> GetPostLikedBy(int postId)
        {
            return repo.GetPostLikedBy(postId);
        }

        public void MessageToPost(Message msg)
        {

            repo.MessageToPost(msg);
        }

    }
}
