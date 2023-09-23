using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Managers.Abstractions;

public record BookSeriesModel

{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int BookId { get; set; }
    public int WriterId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public record CreateBookSeriesModel(string Name,
    int BookId,
    int WriterId);

public interface IBookSeriesManager
{
    Task<BookSeriesModel> CreateBookSeriesAsync(CreateBookSeriesModel model);
    Task<BookSeriesModel> UpdateBookSeriesAsync(int id, CreateBookSeriesModel model);
    Task<bool> DeleteBookSeriesByIdAsync(int id);
    Task<BookSeriesModel> GetBookSeriesByIdAsync(int id);
    Task<BookSeriesModel> GetBookSeriesByNameAsync(string name);
    Task<BookSeriesModel> GetBookSeriesByWriterIdAsync(int id);
    Task<BookSeriesModel> GetBookSeriesByBookIdAsync(int id);
    Task<IEnumerable<BookSeriesModel>> GetBooksAsync();
}
