using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository repo;
        public HomeService(IHomeRepository repo)
        {
            this.repo = repo;
        }
        public void delete(int id)
        {
            repo.delete(id);
        }

        public List<Home> getall()
        {
            return repo.getall();
        }

        public void insert(Home home)
        {
            repo.insert(home);
        }

        public void update(Home home)
        {
            repo.update(home);
        }
    }
}
