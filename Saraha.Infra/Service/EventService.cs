using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository repo;
        public EventService(IEventRepository repo)
        {
            this.repo = repo;
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<Event> GetAll()
        {
            return repo.GetAll();
        }

        public void Insert(Event e)
        {
            repo.Insert(e);
        }

        public void Update(Event e)
        {
            repo.Update(e);
        }
    }
}
