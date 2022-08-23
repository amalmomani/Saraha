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
       

        public Home GetHome()
        {
            return repo.GetHome();
        }

        public void UpdateHome(Home home)
        {
            repo.UpdateHome(home);
        }
    }
}
