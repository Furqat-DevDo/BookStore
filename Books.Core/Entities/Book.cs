using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;

public class Book : BaseEntity
{
    public required string Name { get; set; }
    public int WriterId { get; set; }
    public virtual Writer? Writer { get; set; }
    public required string BodyFileSrc { get; set; }
    public required string CoverImageSrc { get; set; }
    public string?  Description { get; set; }
    public decimal Price { get; set; }
}