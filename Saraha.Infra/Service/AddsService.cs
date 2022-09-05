using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class AddsService : IAddsService
    {
        private readonly IAddsRepository repo;
        public AddsService(IAddsRepository repo)
        {
            this.repo = repo;
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<Adds> GetAll()
        {
            return repo.GetAll();
        }

        public void Insert(Adds adds)
        {
            repo.Insert(adds);
        }

        public void Update(Adds adds)
        {
            repo.Update(adds);
        }
    }
}
