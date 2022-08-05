﻿using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Saraha.Core.Repository
{
    public interface IHomeRepository
    {
        public void insert(Home home);
        public void update(Home home);

        public void delete(int id);

        public List<Home> getall();
    }
}
