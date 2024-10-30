using StackExchange.Redis;
using Store.Core;
using Store.Core.Entities;
using Store.Core.Entities.Order;
using Store.Core.Services.Contract;
using Store.Core.Specifications.OrdersSpes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Orders
{
    public class OrederService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketService _basketService;

        public OrederService(IUnitOfWork unitOfWork,IBasketService basketService)
        {
            _unitOfWork = unitOfWork;
            _basketService = basketService;
        }
 

        public async Task<Core.Entities.Order.Orders> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethod, Core.Entities.Order.Address shippingAddress)
        {
            var basket = await _basketService.GetBusketAsync(basketId);
            if (basket is null) return null;
            var orderItem = new List<OrderItems>();
            if (basket.Items.Count() > 0)
            {
                foreach (var item in basket.Items)
                {
                    var product = await _unitOfWork.Repository<Product, int>().GetAsync(item.Id);
                    var ProductOrderItem = new ProductItemOrder(product.Id, product.Name, product.PictureUrl);
                    var orderItems = new OrderItems(ProductOrderItem, product.Price, item.Quantity);
                    orderItem.Add(orderItems);
                }
            }
            var delivary = await _unitOfWork.Repository<DelevaryMethod, int>().GetAsync(deliveryMethod);
            var subTotal = orderItem.Sum(I => I.price * I.quantity);

            var order =new Core.Entities.Order.Orders(buyerEmail, shippingAddress, delivary, orderItem, subTotal, "");
            await _unitOfWork.Repository<Core.Entities.Order.Orders, int>().AddAsync(order);
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;
            return order;
        }



         async Task<Core.Entities.Order.Orders?> IOrderService.GetOrderByIdForSpecificUserAsync(string buyerEmail, int orderId)
        {
            var spac=new OrderSpecefication(buyerEmail, orderId);
            var order=await _unitOfWork.Repository<Core.Entities.Order.Orders,int>().GetAllWithSpacAsync(spac);
            if (order == null) return null;
            return (Core.Entities.Order.Orders)order;
        }

         async Task<IEnumerable<Core.Entities.Order.Orders>?> IOrderService.GetOrdersForSpecificUserAsync(string buyerEmail)
        {
            var spac=new OrderSpecefication(buyerEmail);
            var orders = await _unitOfWork.Repository<Core.Entities.Order.Orders, int>().GetAllWithSpacAsync(spac);
            if(orders is  null) return null;
            return orders;
        }
    }
}
