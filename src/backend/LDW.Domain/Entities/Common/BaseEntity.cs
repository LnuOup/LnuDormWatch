namespace LDW.Domain.Entities.Common
{
    public class BaseEntity<T> where T: struct
    {
        public T Id { get; set; }
    }
}