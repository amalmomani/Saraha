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
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<Home> GetAll()
        {
            return repo.GetAll();
        }

        public void Insert(Home home)
        {
            repo.Insert(home);
        }

        public void Update(Home home)
        {
            repo.Update(home);
        }
    }
}
