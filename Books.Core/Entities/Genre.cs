using Books.Core.Entities.Abstractions;

namespace Books.Core.Entities;
public class Genre : BaseEntity
{
    public required  string Name { get; set; }
}