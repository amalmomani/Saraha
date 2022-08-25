using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.DTO
{
   public  class OrderAndServiceDTO
    {
        public string username { set; get; }

        public string featurename { set; get; }
        public int featureprice { set; get; }
        public int featureduration { set; get; }
        public int purchaseid { set; get; }
        public DateTime datefrom { set; get; }
       
    }
}
