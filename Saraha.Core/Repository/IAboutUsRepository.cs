using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Repository
{
    public interface IAboutUsRepository
    {
        public void insert(Aboutus aboutus);
        public void update(Aboutus aboutus);

        public void delete(int id);

        public List<Aboutus> getall();
    }
}
