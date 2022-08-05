﻿using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Repository
{
    public interface IAboutUsRepository
    {
        public void Insert(Aboutus aboutus);
        public void Update(Aboutus aboutus);

        public void Delete(int id);

        public List<Aboutus> GetAll();
    }
}
