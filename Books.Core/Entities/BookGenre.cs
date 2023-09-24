using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;

public class BookGenre : BaseEntity
{
    public int GenreId { get; set; }
    public virtual Genre? Genre { get; set; }
    public int BookId { get; set; }
    public virtual Book? Book { get; set; }
}