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
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<Aboutus> GetAll()
        {
            return repo.GetAll(); 
        }

        public void Insert(Aboutus aboutus)
        {
            repo.Insert(aboutus);
        }

        public void Update(Aboutus aboutus)
        {
            repo.Update(aboutus);
        }
    }
}
