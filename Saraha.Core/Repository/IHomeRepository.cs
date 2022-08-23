using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Repository
{
    public interface IHomeRepository
    {
       
        public void UpdateHome(Home home);
       public Home GetHome();
    }
}
