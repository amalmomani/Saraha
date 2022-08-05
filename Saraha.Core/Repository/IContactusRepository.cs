using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Repository
{
    public interface IContactusRepository
    {
        public void insert(Contactus contactus);
        public void update(Contactus contactus);

        public void delete(int id);

        public List<Contactus> getall();
    }
}
