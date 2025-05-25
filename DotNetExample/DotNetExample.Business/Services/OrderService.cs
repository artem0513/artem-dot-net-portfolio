using DotNetExample.Contracts.Repositories;
using DotNetExample.Contracts.Services;
using DotNetExample.Dtos.Dtos;

namespace DotNetExample.Business.Services
{
    internal class OrderService : BaseService<int, OrderDto, IOrderRepository>, IOrderService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository repository, IOrderItemRepository orderItemRepository, IProductRepository productRepository) : base(repository)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
        }

        public async Task Update(int userId, UpdateOrderDto updateOrder, CancellationToken cancellationToken = default)
        {
            if (updateOrder is null)
            {
                throw new ArgumentNullException(nameof(updateOrder));
            }

            var order = await Repository.GetAsync(updateOrder.Id, cancellationToken: cancellationToken);

            if (order.CustomerId != userId)
            {
                throw new ArgumentException("User cannot update orders which don't belong to them");
            }

            var orderItems = (await _orderItemRepository.GetByOrderId(order.Id, cancellationToken)).ToDictionary(x => x.Id);

            var products = (await _productRepository.GetAsync(updateOrder.OrderItems.Select(x => x.ProductId), cancellationToken))
                .ToDictionary(x => x.Id);

            foreach (var orderItem in updateOrder.OrderItems)
            {
                if (orderItems.TryGetValue(orderItem.Id, out var itemToUpdate))
                {
                    itemToUpdate.ProductId = orderItem.ProductId;
                    itemToUpdate.UnitPrice = products[orderItem.ProductId].Price * orderItem.Quantity;

                    await _orderItemRepository.UpdateAsync(itemToUpdate, false, cancellationToken);
                }
                else
                {
                    await _orderItemRepository.AddAsync(new OrderItemDto
                    {
                        ProductId = orderItem.ProductId,
                        OrderId = order.Id,
                        UnitPrice = products[orderItem.ProductId].Price * orderItem.Quantity,
                        Quantity = orderItem.Quantity
                    }, false, cancellationToken);
                }
            }

            var orderItemsToDelete = updateOrder.OrderItems.Select(x => x.Id).Except(orderItems.Keys);

            await _orderItemRepository.DeleteAsync(orderItemsToDelete, true, cancellationToken);
        }
    }
}
