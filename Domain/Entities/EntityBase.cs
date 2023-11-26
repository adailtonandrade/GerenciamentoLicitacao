namespace Domain.Entities
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}