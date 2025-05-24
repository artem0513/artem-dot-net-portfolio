namespace DotNetExample.DataAccessLayer.Entities
{
    public class OrderEntity : BaseEntity<int>
    {
        public int CustomerId { get; set; }
        public ApplicationUser? Customer { get; set; }

        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }

        public ICollection<OrderItemEntity>? Items { get; set; }
    }
}
