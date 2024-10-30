using StackExchange.Redis;
using Store.Core.Entities.Identity;
using Store.Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services.Contract
{
    public interface IOrderService
    {
        public Task<Orders> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethod, Entities.Order.Address shippingAddress);

        public Task<IEnumerable<Orders>?> GetOrdersForSpecificUserAsync(string buyerEmail);

        public Task<Orders?> GetOrderByIdForSpecificUserAsync(string buyerEmail, int orderId);
    }
}
