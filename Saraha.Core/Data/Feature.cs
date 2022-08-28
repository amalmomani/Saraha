using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Data
{
  public class Feature
    {
        public decimal FeatureId { get; set; }
        public string FeatureName { get; set; }
        public decimal? FeaturePrice { get; set; }
        public decimal? FeatureDuration { get; set; }
        public string ImagePath { get; set; }
        public string? FeatureDescribtion { get; set; }
        public decimal? RateStars { get; set; }
        public decimal? RateCount { get; set; }
        public decimal? OldPrice { get; set; }
        public string? VedioLink { get; set; }






    }
}
