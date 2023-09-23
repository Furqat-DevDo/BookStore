namespace Books.Manage.Managers.Abstractions;

public record BookGenreModel
{
    public int BookId { get; set; }
    public int GenreId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public record CreateBookGenreModel(int BookId, int GenreId);

public interface IBookGenreManager
{
    Task<BookGenreModel> CreateBookGenreAsync(CreateBookGenreModel model);
    Task<bool> DeleteBookGenreAsync(int id);
    Task<IEnumerable<BookGenreModel>> GetByGenreIdAsync(int id);
    Task<IEnumerable<BookGenreModel>> GetByBookIdAsync(int id);
}
