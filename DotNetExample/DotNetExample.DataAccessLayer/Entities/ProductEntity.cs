namespace DotNetExample.DataAccessLayer.Entities
{
    public class ProductEntity : BaseEntity<int>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
