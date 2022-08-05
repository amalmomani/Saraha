using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
    public interface IContactusService
    {
        public void Insert(Contactus contactus);
        public void Update(Contactus contactus);

        public void Delete(int id);

        public List<Contactus> GetAll();
    }
}
