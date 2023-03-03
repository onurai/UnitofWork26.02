namespace Task.Data.Entities
{
    public class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
