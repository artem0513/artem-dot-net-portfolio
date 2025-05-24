using AutoMapper;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Mappings.DtoMappings
{
    internal class OrderItemDtoMapping : Profile
    {
        public OrderItemDtoMapping()
        {
            CreateMap<OrderItemEntity, OrderItemDto>();
        }
    }
}
