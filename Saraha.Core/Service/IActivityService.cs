using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;

namespace Saraha.Core.Service
{
   public interface IActivityService
    {
        public List<Activity> getallActivity();
        public bool createActivity(Activity activity);
        public bool UpdateActivity(Activity activity);
        public bool deleteActivity(int? id);
    }
}
