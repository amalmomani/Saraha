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
       
        public Aboutus GetAboutUs()
        {
            return repo.GetAboutUs(); 
        }


        public void UpdateAboutUs(Aboutus aboutus)
        {
            repo.UpdateAboutUs(aboutus);
        }
    }
}
