using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Core.Dtos.Orders;
using Store.Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Mapping.Orders
{
    public class OrderProfile : Profile
    {
        public OrderProfile(IConfiguration configuration)
        {
            CreateMap<Entities.Order.Orders, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, option => option.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.DeliveryMethodCost, option => option.MapFrom(s => s.DeliveryMethod.Cost));
            CreateMap<Address,AddressDto>().ReverseMap();
            CreateMap<OrderItems,OrderItemsDto>()
                .ForMember(d => d.ProductId, option => option.MapFrom(s => s.product.ProductId))
                .ForMember(d => d.ProductName, option => option.MapFrom(s => s.product.ProductName))
                .ForMember(d => d.PictureUrl, option => option.MapFrom(s => $"{configuration["BASEURL"]}{s.product.PictureURL}")); 
        }
    }
}
