using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
    public interface IEventService
    {
        public void Insert(Event e);
        public void Update(Event e);

        public void Delete(int id);

        public List<Event> GetAll();
    }
}
