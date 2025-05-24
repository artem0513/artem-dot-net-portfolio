using AutoMapper;
using DotNetExample.Contracts.Repositories;
using DotNetExample.DataAccessLayer;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Repositories
{
    internal class OrderRepository : BaseRepository<int, OrderDto, OrderEntity, ApplicationDbContext>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
