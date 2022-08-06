using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
 public interface IPostcommentRepository
    {
        public void DeleteComment(int id);

        public List<Postcomment> GetAllComments();
        public void CreateComment(Postcomment comment);

        public void UpdateComment(Postcomment Comment, int id);
    }
}
