using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Dtos.Basket
{
    public class CustomerBasketDtos
    {
        public string Id { get; set; }
        public List<BaskitItem> Items { get; set; }
        public int? DelivaryMethodId { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
