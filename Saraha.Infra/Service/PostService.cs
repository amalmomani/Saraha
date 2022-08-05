﻿using Saraha.Core.Data;
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
        }

        public void Insert(Post post)
        {
            repo.Insert(post);
        }

        public void PinPost(int id)
        {
            repo.PinPost(id);
        }

        public void Update(Post post)
        {
            repo.Update(post);
        }
    }
}