using Microsoft.AspNetCore.Http;

namespace Books.Manage.Managers.Abstractions;

public record BookModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int WriterId { get; set; }
    public List<GenreModel>? Genres { get; set; }
    public required string FilePath { get; set; }
    public string? CoverImageSrc { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public decimal Price { get; set; }
}

public record CreateBookModel(
    string Name,
    int WriterId,
    List<GenreModel>? Genres,
    string FilePath,
    string CoverImageSrc,
    string? Description,
    decimal Price);

public class ResultBooksModel
{
    public List<string> Genres { get; set; } = new();
    public required string AuthorName { get; set; }
    public string? FilePath { get; set; }
    public string? CoverImageSrc { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
}

public interface IBookManager
{
    Task<BookModel> CreateBookAsync(CreateBookModel model);
    Task<BookModel> UpdateBookAsync(int id,CreateBookModel model);
    Task<bool> DeleteBookAsync(int id);
    Task<BookModel> GetBookByIdAsync(int id);
    Task<BookModel> GetBookByNameAsync(string name);
    Task<BookModel> GetBookByWriterId(int id);
    Task<IEnumerable<BookModel>> GetBooksAsync();
}





