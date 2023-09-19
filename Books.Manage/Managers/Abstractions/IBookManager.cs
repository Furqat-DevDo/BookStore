namespace Books.Manage.Managers.Abstractions;

public class BookModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int WriterId { get; set; }
    public List<GenreModel>? Genres { get; set; }
    public required string FilePath { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public record CreateBookModel(
    string Name,
    int WriterId,
    List<GenreModel>? Genres,
    string FilePath,
    string? Description);

public interface IBookManager
{
    Task<BookModel> CreateBookAsync(CreateBookModel model);
    Task<BookModel> UpdateBookAsync(int id,CreateBookModel model);
    Task<bool> DeleteBookAsync(int id);
    Task<BookModel> GetBookByIdAsync(int id);
    Task<BookModel> GetBookByNameAsync(string name);
    Task<BookModel> GetBookByWriterId(int id);
    Task<List<BookModel>> GetBooksAsync();
}





