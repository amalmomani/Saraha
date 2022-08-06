using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
 public interface IPostlikeService
    {

        public void CreateLike(Postlike post);

        public List<Postlike> GetAllLikes();
        public void DeleteLike(int id);
    }
}
