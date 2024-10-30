using StackExchange.Redis;
using Store.Core.Dtos.Basket;
using Store.Core.Entities;
using Store.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repositorty.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase databas;

        public BasketRepository(IConnectionMultiplexer redis) 
        {
            databas = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string busketId)
        {
            return await databas.KeyDeleteAsync(busketId);
        }

        public async Task<CustmerBusket> GetBasketAsync(string basketId)
        {
            var basket= await databas.StringGetAsync(basketId);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustmerBusket>(basket);
        }

        public async Task<CustmerBusket> UpdateBasketAsync(CustmerBusket basket)
        {
            var createdOrUpdatedBasket = await databas.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (createdOrUpdatedBasket is false)
            {
                return null;
            }
            return await GetBasketAsync(basket.Id);
        }

        public async Task UpdateBasketAsync(CustomerBasketDtos customerBasketDtos)
        {
            // الخطوة 1: تحويل الـ Dto إلى كائن من نوع CustmerBusket
            var customerBasket = new CustmerBusket
            {
                Id = customerBasketDtos.Id,
                Items = customerBasketDtos.Items.Select(item => new BaskitItem
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    PicturUrl = item.PicturUrl
                }).ToList()
            };

            // الخطوة 2: استدعاء الدالة UpdateBasketAsync التي تقبل CustmerBusket 
            await UpdateBasketAsync(customerBasket);
        }

    }
}
