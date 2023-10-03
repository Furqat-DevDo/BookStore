namespace Books.Web.Models;

public class BookCreateViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string WriterName { get; set; }
    public List<string> Genres { get; set; }
    public IFormFile BookFile { get; set; }
    public IFormFile CoverImage { get; set; }
    public decimal Price { get; set; }
}
