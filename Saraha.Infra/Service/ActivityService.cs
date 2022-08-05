using System;
using System.Collections.Generic;
using System.Text;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;

namespace Saraha.Infra.Service
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository repo;
        public ActivityService(IActivityRepository repo)
        {
            this.repo = repo;
        }
        public bool createActivity(Activity activity)
        {
            return repo.createActivity(activity);
        }

        public bool deleteActivity(int? id)
        {
            return repo.deleteActivity(id);
        }

        public List<Activity> getallActivity()
        {
            return repo.getallActivity();
        }

        public bool UpdateActivity(Activity activity)
        {
            return repo.UpdateActivity(activity);
        }
    }
}
