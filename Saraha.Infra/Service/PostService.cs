using Saraha.Core.Data;
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
        public void delete(int id)
        {
            repo.delete(id);
        }

        public List<Post> getall()
        {
            return repo.getall();
        }

        public void insert(Post post)
        {
            repo.insert(post);
        }

        public void update(Post post)
        {
            repo.update(post);
        }
    }
}
