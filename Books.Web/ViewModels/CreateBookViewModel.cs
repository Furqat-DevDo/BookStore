using Books.Manage.Managers.Abstractions;

namespace Books.Web.ViewModels;

public class CreateBookViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string WriterName { get; set; }
    public IFormFile CoverImage { get; set; }           
    public IFormFile BookFile { get; set; }
    public List<GenreModel> GenreList { get; set; }
}