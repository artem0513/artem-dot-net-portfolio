namespace DotNetExample.Dtos.Dtos
{
    public class UpsertOrderItemDto : BaseDto<int>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
