using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
  public  class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository repo;
        public FeatureService(IFeatureRepository repo)
        {
            this.repo = repo;
        }
        public void DeleteFeature(int id)
        {
            repo.DeleteFeature(id);
        }

        public List<Feature> GetAllFeatures()
        {
            return repo.GetAllFeatures();
        }
        public void CreateFeature(Feature feature)
        {
            repo.CreateFeature(feature);
        }
        public void UpdateFeature(Feature feature)
        {
            repo.UpdateFeature(feature);
        }
        public List<FeatureSalesDTO> FeatureSales()
        {
           return repo.FeatureSales();


        }
        public List<Charts> Chart() {
            return repo.Chart();
        }


    }
}
