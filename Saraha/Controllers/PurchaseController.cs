using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.DTO;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            this.purchaseService = purchaseService;
        }


        [HttpPost("CreatePurchase")]
        public void CreatePurchase([FromBody] Purchase purchase)
        {
            purchaseService.CreatePurchase(purchase);
        }

        [HttpGet("GetPurchases")]
        public List<Purchase> GetAllPurchase()
        {
            return purchaseService.GetAllPurchases();
        }

        [HttpDelete("RemovePurchase/{id}")]
        public void RemovePurchase(int id)
        {
            purchaseService.DeletePurchase(id);
        }

        [HttpGet("GetOrders")]
        public List<OrderAndAerviceDTO> GetOrders()
        {
            return purchaseService.GetOrders();
        }



    }
}
