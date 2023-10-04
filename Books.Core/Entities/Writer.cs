using Books.Core.Entities.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Books.Core.Entities;

public class Writer : BaseEntity
{
    public required string FullName { get; set; }
    public ICollection<Book>? Books { get; set; }
    public ICollection<BookSeries>? BookSeries { get; set; }
    public  required DateOnly BirthDate { get; set; }
    public required string WriterImage { get; set; }
}