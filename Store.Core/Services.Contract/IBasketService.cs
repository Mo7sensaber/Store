using Store.Core.Dtos.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services.Contract
{
    public interface IBasketService
    {
        Task<CustomerBasketDtos?> GetBusketAsync(string BysketId);
        Task<CustomerBasketDtos?> UpdateBusketAsync(CustomerBasketDtos busketDto);

        Task<bool> DeleteBusketAsync(string BusketId);




    }
}
