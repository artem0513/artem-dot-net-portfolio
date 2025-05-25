using AutoMapper;
using DotNetExample.Contracts.Repositories;
using DotNetExample.DataAccessLayer;
using DotNetExample.DataAccessLayer.Entities;
using DotNetExample.Dtos.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DotNetExample.Business.Repositories
{
    internal class OrderItemRepository : BaseRepository<int, OrderItemDto, OrderEntity, ApplicationDbContext>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task AddItemToOrderAsync(int userId, UpsertOrderItemDto item, CancellationToken cancellationToken = default)
        {
            var order = await DbContext.Orders.SingleAsync(x => x.Id == item.OrderId);

            if (order.CustomerId != userId)
            {
                throw new ArgumentException("User cannot update orders which don't belong to them");
            }

            var productPrice = (await DbContext.Products
                .Select(x => new { x.Price, x.Id })
                .SingleAsync(x => x.Id == item.ProductId)).Price;

            var totalItemPrice = productPrice * item.Quantity;

            order.Total += totalItemPrice;

            var orderItem = new OrderItemEntity
            {
                OrderId = item.OrderId,
                Quantity = item.Quantity,
                ProductId = item.ProductId,
                UnitPrice = totalItemPrice
            };

            await DbContext.OrderItems.AddAsync(orderItem);

            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<OrderItemDto>> GetByOrderId(int orderId, int userId, CancellationToken cancellationToken = default)
        {
            var customerId = (await DbContext.Orders.SingleAsync(x => x.Id == orderId)).CustomerId;

            if (customerId != userId)
            {
                throw new ArgumentException("User cannot update orders which don't belong to them");
            }

            return await GetByOrderId(orderId, cancellationToken);
        }

        public async Task<ICollection<OrderItemDto>> GetByOrderId(int orderId, CancellationToken cancellationToken = default)
        {
            var itemEntities = await DbContext.OrderItems.Where(x => x.OrderId == orderId).ToArrayAsync(cancellationToken);
            return itemEntities.Select(Mapper.Map<OrderItemDto>).ToArray();
        }
    }
}
