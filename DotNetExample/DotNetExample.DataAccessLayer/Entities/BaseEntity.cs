namespace DotNetExample.DataAccessLayer.Entities
{
    public abstract class BaseEntity<T>
    {
        public required T Id { get; set; }
    }
}
