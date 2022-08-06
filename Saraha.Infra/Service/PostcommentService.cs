using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
     public class PostcommentService : IPostcommentService 
    {

        private readonly IPostcommentRepository repo;
        public PostcommentService(IPostcommentRepository repo)
        {
            this.repo = repo;
        }


        public void DeleteComment(int id)
        {
            repo.DeleteComment(id);


        }

        public List<Postcomment> GetAllComments()
        {
           return this.repo.GetAllComments();

        }
        public void CreateComment(Postcomment comment)
        {
            repo.CreateComment(comment);

        }
        public void UpdateComment(Postcomment Comment, int id)
        {
            repo.UpdateComment(Comment, id);

        }

    }
}
