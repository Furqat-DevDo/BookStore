namespace Books.Core.Entities;

public class BookGenre 
{
    public int GenreId { get; set; }
    public virtual Genre? Genre { get; set; }
    public int BookId { get; set; }
    public virtual Book? Book { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set;}
}