using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
    public interface IAboutUsService
    {
        public void insert(Aboutus aboutus);
        public void update(Aboutus aboutus);

        public void delete(int id);

        public List<Aboutus> getall();
    }
}
