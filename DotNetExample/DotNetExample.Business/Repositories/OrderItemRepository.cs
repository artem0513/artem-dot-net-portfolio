using AutoMapper;
using DotNetExample.Contracts.Repositories;
using DotNetExample.DataAccessLayer;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Repositories
{
    internal class OrderItemRepository : BaseRepository<int, OrderItemDto, OrderEntity, ApplicationDbContext>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
