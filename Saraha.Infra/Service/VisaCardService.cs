using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
   public class VisaCardService: IVisaCardServices
    {
        private readonly IVisaCardRepository repo;
        public VisaCardService(IVisaCardRepository repo)
        {
            this.repo = repo;
        }
        public List<VisaCard> GetallVisa()
        {
            return repo.GetallVisa();
        }
        public void UpdateVisa(VisaCard visa)
        {
            repo.UpdateVisa(visa);
        }
    }
}
