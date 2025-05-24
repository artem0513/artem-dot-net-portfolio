namespace DotNetExample.Dtos.Dtos
{
    public class OrderDto : BaseDto<int>
    {
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
    }
}
