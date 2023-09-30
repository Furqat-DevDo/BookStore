using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;

public class Writer : BaseEntity
{
    public required string FullName { get; set; }
    public ICollection<Book>? Books { get; set; }
    public ICollection<BookSeries>? BookSeries { get; set; }
    public  required DateTime BirthDate { get; set; }
}