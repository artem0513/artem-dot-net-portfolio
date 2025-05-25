namespace DotNetExample.Dtos.Dtos
{
    public class UpdateOrderDto : BaseDto<int>
    {
        public int CustomerId { get; set; }
        public List<UpsertOrderItemDto> OrderItems = new List<UpsertOrderItemDto>();
    }
}
