namespace DotNetExample.DataAccessLayer.Entities
{
    public class CategoryEntity : BaseEntity<int>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<ProductEntity>? Products { get; set; }
    }
}
