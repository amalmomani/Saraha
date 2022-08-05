﻿using Saraha.Core.Data;
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
        public void delete(int id)
        {
            repo.delete(id);
        }

        public List<Contactus> getall()
        {
            return repo.getall();
        }

        public void insert(Contactus contactus)
        {
            repo.insert(contactus);
        }

        public void update(Contactus contactus)
        {
            repo.update(contactus);
        }
    }
}
