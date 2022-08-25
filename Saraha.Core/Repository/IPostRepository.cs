using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Repository
{
    public interface IPostRepository
    {
        public void Insert(Post post);
        public void Update(Post post);

        public void Delete(int id);

        public List<Post> GetAll();
        public void PinPost(int id);
        public List<PostUserComment> PostUserComments();
        public List<Post> GetPostByUserId(int userId);

    }
}
