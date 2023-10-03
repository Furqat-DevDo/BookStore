using System.ComponentModel.DataAnnotations;

namespace Books.Web.Models;

public class BookCreateViewModel
{
    [MinLength(5, ErrorMessage = "Length of book name must be more than 4 characters")]
    public required string Name { get; set; }


    public string Description { get; set; }
    public required string WriterName { get; set; }
    public required List<string> Genres { get; set; }
    public required IFormFile BookFile { get; set; }
    public IFormFile CoverImage { get; set; }
    public  decimal Price { get; set; }
}
