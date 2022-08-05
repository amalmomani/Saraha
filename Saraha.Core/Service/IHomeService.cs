﻿using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Service
{
    public interface IHomeService
    {
        public void Insert(Home home);
        public void Update(Home home);

        public void Delete(int id);

        public List<Home> GetAll();
    }
}
