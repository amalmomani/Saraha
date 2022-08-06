using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
   public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository repo;
        public PurchaseService(IPurchaseRepository repo)
        {
            this.repo = repo;
        }
        public void CreatePurchase(Purchase purchase)
        {
            repo.CreatePurchase(purchase);
        }

        public List<Purchase> GetAllPurchases()
        {

            return this.GetAllPurchases();
        }
        public void DeletePurchase(int id)
        {
            repo.DeletePurchase(id);
        }
    }
}
