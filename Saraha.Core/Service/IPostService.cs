using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
    public interface IPostService
    {
        public void Insert(Post post);
        public void Update(Post post);

        public void Delete(int id);

        public List<Post> GetAll();
    }
}
