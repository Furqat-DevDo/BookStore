using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;

public class BookSeries : BaseEntity
{
    public required string Name { get; set; }
    public List<int> BookIds { get; set; } = new ();
    public int WriterId { get; set; }
    public virtual Writer? Writer{ get; set; }
}