using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class AboutUsService : IAboutUsService
    {
        private readonly IAboutUsRepository repo;
        public AboutUsService(IAboutUsRepository repo)
        {
            this.repo = repo;
        }
        public void delete(int id)
        {
            repo.delete(id);
        }

        public List<Aboutus> getall()
        {
            return repo.getall(); 
        }

        public void insert(Aboutus aboutus)
        {
            repo.insert(aboutus);
        }

        public void update(Aboutus aboutus)
        {
            repo.update(aboutus);
        }
    }
}
