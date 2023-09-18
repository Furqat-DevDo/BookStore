namespace Books.Core.Entities.Abstractions;

public abstract class BaseEntity
{
    public virtual int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}