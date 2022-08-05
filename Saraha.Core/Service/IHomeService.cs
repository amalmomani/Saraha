using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
    public interface IHomeService
    {
        public void insert(Home home);
        public void update(Home home);

        public void delete(int id);

        public List<Home> getall();
    }
}
