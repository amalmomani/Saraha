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

        public string GetVisa(string card, int cost)
        {
            return repo.GetVisa(card, cost);
        }

        public void UpdateVisa(VisaCard visa, int cost)
        {
            repo.UpdateVisa(visa,cost);
        }
    }
}
