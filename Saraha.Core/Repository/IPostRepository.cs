using Saraha.Core.Data;
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
        public void PinPost(Post post);
    }
}
