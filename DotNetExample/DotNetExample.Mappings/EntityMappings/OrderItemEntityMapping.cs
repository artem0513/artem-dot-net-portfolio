using AutoMapper;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Mappings.EntityMappings
{
    internal class OrderItemEntityMapping : Profile
    {
        public OrderItemEntityMapping()
        {
            CreateMap<OrderItemDto, OrderItemEntity>();
        }
    }
}
