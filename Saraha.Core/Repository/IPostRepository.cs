using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Repository
{
    public interface IPostRepository
    {
        public void insert(Post post);
        public void update(Post post);

        public void delete(int id);

        public List<Post> getall();
    }
}
