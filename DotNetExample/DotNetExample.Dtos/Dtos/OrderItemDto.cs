namespace DotNetExample.Dtos.Dtos
{
    public class OrderItemDto : BaseDto<int>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
