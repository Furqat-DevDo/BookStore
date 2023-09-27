namespace Books.Web.ViewModels;

public class BookViewModel
{
    public List<BookModels> Books { get; set; } = new();
}

public class BookModels
{

    public List<string> Genres { get; set; } = new();
    public required string AuthorName { get; set; }
    public string? CoverImageSrc { get; set; }
    public required string Name  { get; set; }
    public decimal Price { get; set; }
}