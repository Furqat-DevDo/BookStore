using Books.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Managers.Abstractions;

public class BookSeriesModel
{
    public int Id { get; set; }
    public string Name { get; set; }
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
    Task<BookSeriesModel> UpdateBookSeriesAsync(CreateBookSeriesModel model);
    Task<bool> DeleteBookSeriesById(int id);
    Task<BookSeriesModel> GetBookSeriesById(int id);
    Task<BookSeriesModel> GetBookSeriesByName(string name);
    Task<BookSeriesModel> GetBookSeriesByWriterId(int id);
    Task<BookSeriesModel> GetBookSeriesByBookId(int id);
}
