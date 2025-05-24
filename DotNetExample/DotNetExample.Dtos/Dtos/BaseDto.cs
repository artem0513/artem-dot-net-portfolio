namespace DotNetExample.Dtos.Dtos
{
    public abstract class BaseDto<T>
    {
        public required T Id { get; set; }
    }
}
