 using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;

public class Book : BaseEntity
{
    public required string Name { get; set; }
    public int WriterId { get; set; }
    public virtual Writer? Writer { get; set; }
    public ICollection<Genre>? Genres { get; set; }
    public required string FilePath { get; set; }
    public string?  Description { get; set; }
}