using Books.Core.Entities;

namespace Books.Manage.Managers.Abstractions;

public record CreateBookGenreModel(int BookId);
public record BookGenreModel
{
    public int BookId { get; set; }
    public Book? Books { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set;}


}
public interface IBookGenreManager
{
    Task<BookGenreModel> CreateBookGenreAsync(CreateBookGenreModel model);
    Task<BookGenreModel> UpdateBookGenreAsync(int id, CreateBookGenreModel model);
    Task<bool> DeleteBookGenreAsync(int id);
    Task<BookGenreModel> GetBookGenreByIdAsync(int BookId);
    Task<IEnumerable<BookGenreModel>> GetBookGenresAsync();
}
