namespace DotNetExample.Dtos.Dtos
{
    public class CategoryDto : BaseDto<int>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
