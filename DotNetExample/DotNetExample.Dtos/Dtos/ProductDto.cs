namespace DotNetExample.Dtos.Dtos
{
    public class ProductDto : BaseDto<int>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
