﻿using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;

namespace Saraha.Core.Service
{
   public interface IActivityService
    {
        public List<Activity> GetallActivity();
        public void CreateActivity(Activity activity);
        public void UpdateActivity(Activity activity);
        public void DeleteActivity(int? id);
    }
}
