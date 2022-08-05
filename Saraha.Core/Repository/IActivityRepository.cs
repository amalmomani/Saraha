using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;

namespace Saraha.Core.Repository
{
    public interface IActivityRepository
    {
        public List<Activity> getallActivity();
        public bool createActivity(Activity activity);
        public bool UpdateActivity(Activity activity);
        public bool deleteActivity(int? id);
    }
}
