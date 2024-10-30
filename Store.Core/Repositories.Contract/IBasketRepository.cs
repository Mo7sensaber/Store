using Store.Core.Dtos.Basket;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Repositories.Contract
{
    public interface IBasketRepository
    {
        Task<CustmerBusket> GetBasketAsync(string basketId);
        Task<CustmerBusket> UpdateBasketAsync(CustmerBusket busket);
        Task<bool> DeleteBasketAsync(string busketId);
        Task UpdateBasketAsync(CustomerBasketDtos customerBasketDtos);
    }
}
