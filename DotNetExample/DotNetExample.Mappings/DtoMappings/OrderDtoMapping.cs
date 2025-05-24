using AutoMapper;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Mappings.DtoMappings
{
    internal class OrderDtoMapping : Profile
    {
        public OrderDtoMapping()
        {
            CreateMap<OrderEntity, OrderItemDto>();
        }
    }
}
