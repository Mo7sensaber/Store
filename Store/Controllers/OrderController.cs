using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Store.Core;
using Store.Core.Dtos.Orders;
using Store.Core.Entities.Identity;
using Store.Core.Entities.Order;
using Store.Core.Services.Contract;
using Store.Error;
using System.Security.Claims;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IOrderService orderService, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _orderService = orderService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrdersDto model)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail is null) return Unauthorized(value: new APIErrorResponse(StatusCodes.Status401Unauthorized));

            var address = _mapper.Map<Core.Entities.Order.Address>(model.shipToAddress);

            var order = await _orderService.CreateOrderAsync(userEmail, model.BasketId, model.DelivaryMethodId, address);
            if (order is null) return BadRequest(error: new APIErrorResponse(StatusCodes.Status400BadRequest));

            return Ok(_mapper.Map<OrderToReturnDto>(order));
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderForSpecificUser()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail is null) return Unauthorized(value: new APIErrorResponse(StatusCodes.Status401Unauthorized));
            var orders = await _orderService.GetOrdersForSpecificUserAsync(userEmail);
            if (orders is null) return BadRequest(error: new APIErrorResponse(StatusCodes.Status400BadRequest));
            return (IActionResult)_mapper.Map<IEnumerable<OrderToReturnDto>>(orders);
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderForSpecificUser(int orderId)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail is null) return Unauthorized(value: new APIErrorResponse(StatusCodes.Status401Unauthorized));
            var orders = await _orderService.GetOrderByIdForSpecificUserAsync(userEmail,orderId);
            if (orders is null) return NotFound( new APIErrorResponse(StatusCodes.Status404NotFound));
            return (IActionResult)_mapper.Map<OrderToReturnDto>(orders);
        }
        [HttpGet("DelivaryMethod")]
        public async Task<IActionResult> GetDelivaryMethod()
        {
            var delevaryMethod=await _unitOfWork.Repository<DelevaryMethod,int>().GetAllAsync();
            if (delevaryMethod is null) return BadRequest(new APIErrorResponse(StatusCodes.Status400BadRequest));
            return Ok(delevaryMethod);
        }
    }
}
