using Store.Core.Dtos.Auth;
using Store.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Dtos.Orders
{
    public class OrdersDto
    {
        public string BasketId { get; set; }
        public int DelivaryMethodId { get; set; }
        public AddressDtos shipToAddress { get; set; }
    }
}
