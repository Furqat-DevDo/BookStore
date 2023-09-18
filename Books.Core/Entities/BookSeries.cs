using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;

public class BookSeries : BaseEntity
{
    public required string Name { get; set; }
    public int BookId { get; set; }
    public virtual Book? Book { get; set; }
    public int WriterId { get; set; }
    public virtual Writer? Writer{ get; set; }
}