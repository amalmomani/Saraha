﻿using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
  public  interface IPostlikeRepository
    {
        public void CreateLike(Postlike post);

        public List<Postlike> GetAllLikes();
        public void DeleteLike(int id);
    }
}