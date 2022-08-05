using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class ContactusService : IContactusService
    {
        private readonly IContactusRepository repo;
        public ContactusService(IContactusRepository repo)
        {
            this.repo = repo;
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<Contactus> GetAll()
        {
            return repo.GetAll();
        }

        public void Insert(Contactus contactus)
        {
            repo.Insert(contactus);
        }

        public void Update(Contactus contactus)
        {
            repo.Update(contactus);
        }
    }
}
