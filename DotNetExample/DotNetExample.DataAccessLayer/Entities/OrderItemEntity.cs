namespace DotNetExample.DataAccessLayer.Entities
{
    public class OrderItemEntity : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public OrderEntity? Order { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
