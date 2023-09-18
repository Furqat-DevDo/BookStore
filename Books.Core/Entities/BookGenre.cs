using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;

public class BookGenre : BaseEntity
{
    public int BookId { get; set; }
    public virtual Book? Book { get; set; }
}