using Saraha.Core.Data;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
  public  class FeatureService : IFeatureService
    {
        public void DeleteFeature(int id)
        {
            this.DeleteFeature(id);
        }

        public List<Feature> GetAllFeatures()
        {
            return this.GetAllFeatures();
        }
        public void CreateFeature(Feature feature)
        {
            this.CreateFeature(feature);
        }
        public void UpdateFeature(Feature feature, int id)
        {
            this.UpdateFeature(feature, id);
        }
    }
}
