using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Dtos.Basket;
using Store.Core.Entities;
using Store.Core.Repositories.Contract;
using Store.Error;

namespace Store.Controllers
{

    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository,IMapper mapper) 
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<CustmerBusket>> GetBasket(string? id)
        {
            if (id == null)
                return BadRequest(new APIErrorResponse(400, "Invalid request"));
                var basket=await _basketRepository.GetBasketAsync(id);
                if (basket == null) { new CustmerBusket() { Id = id }; }
                return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<CustmerBusket>> CreateOrUpdateBasket(CustomerBasketDtos model)
        {
            var basket =await _basketRepository.UpdateBasketAsync(_mapper.Map<CustmerBusket>(model));
            if (basket == null) return BadRequest(new APIErrorResponse(400));
            return Ok(basket);
        }
        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
             await _basketRepository.DeleteBasketAsync(id);
        }
    }
}
