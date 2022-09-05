using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
    public interface IAddsRepository
    {
        public void Insert(Adds adds);
        public void Update(Adds adds);

        public void Delete(int id);

        public List<Adds> GetAll();
    }
}
