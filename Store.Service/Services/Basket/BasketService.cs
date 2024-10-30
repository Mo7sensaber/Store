using AutoMapper;
using Store.Core.Dtos.Basket;
using Store.Core.Entities;
using Store.Core.Repositories.Contract;
using Store.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Service.Services.Busket
{
    public class BusketService : IBasketService
    {
        private readonly IBasketRepository _busketRepository;
        private readonly IMapper _mapper;

        public BusketService(IBasketRepository busketRepository, IMapper mapper)
        {
            this._busketRepository = busketRepository;
            this._mapper = mapper;
        }

        public async Task<CustomerBasketDtos?> GetBusketAsync(string BysketId)
        {
            var busket = await _busketRepository.GetBasketAsync(BysketId);
            if (busket == null) return _mapper.Map<CustomerBasketDtos>(new CustmerBusket()
            {
                Id = BysketId,
            });
            return _mapper.Map<CustomerBasketDtos?>(busket);
        }

        public async Task<CustomerBasketDtos?> UpdateBusketAsync(CustomerBasketDtos busketDto)
        {
            var busket = await _busketRepository.UpdateBasketAsync(_mapper.Map<CustmerBusket>(busketDto));
            if (busket is null) return null;
            return _mapper.Map<CustomerBasketDtos?>(busket);
        }

        public async Task<bool> DeleteBusketAsync(string BusketId)
        {
            return await _busketRepository.DeleteBasketAsync(BusketId);
        }
    }
}