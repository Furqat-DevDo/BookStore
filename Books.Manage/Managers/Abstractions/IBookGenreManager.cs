using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Managers.Abstractions;

public record BookGenreModel
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int GenreId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public record CreateBookGenreModel(int BookId, int GenreId);

public interface IBookGenreManager
{
    Task<BookGenreModel> CreateBookGenreAsync(CreateBookGenreModel model);
    Task<BookGenreModel> UpdateBookGenreAsync(int id, CreateBookGenreModel model);
    Task<bool> DeleteBookGenreAsync(int id);
    Task<BookGenreModel> GetBookGenreByIdAsync(int id);
    Task<BookGenreModel> GetBookGenreByGenreIdAsync(int id);
    Task<BookGenreModel> GetBookGenreByBookIdAsync(int id);
    Task<IEnumerable<BookGenreModel>> GetBookGenresAsync();
}
