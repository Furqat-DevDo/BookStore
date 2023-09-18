using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;

public class BookFile : BaseEntity
{
    public new Guid Id { get; set; }
    public required string Path { get; set; }
    public float Size { get; set; }
    public int  BookId { get; set; }
    public virtual Book? Book { get; set; }
    public required string FileExtension { get; set; }
}