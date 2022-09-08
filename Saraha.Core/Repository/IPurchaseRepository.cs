using Saraha.Core.Data;
using Saraha.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Repository
{
   public interface IPurchaseRepository
    {
        public void CreatePurchase(Purchase purchase);

        public List<Purchase> GetAllPurchases();
        public void DeletePurchase(int id);
        public List<OrderAndServiceDTO> GetOrders();
        public void IsPremiumExpire();
    }
}
