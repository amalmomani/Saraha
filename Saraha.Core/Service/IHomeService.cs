using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
    public interface IHomeService
    {
        public void UpdateHome(Home home);
        public Home GetHome();
    }
}
