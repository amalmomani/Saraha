using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
    public interface IAboutUsService
    {
        public void UpdateAboutUs(Aboutus aboutus);
        public Aboutus GetAboutUs();
    }
}
