using AutoMapper;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Mappings.EntityMappings
{
    internal class OrderEntityMapping : Profile
    {
        public OrderEntityMapping()
        {
            CreateMap<OrderItemDto, OrderEntity>();
        }
    }
}
