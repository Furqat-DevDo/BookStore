namespace Books.Manage.Managers.Abstractions;

public record BookSeriesModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<int> BookIds { get; set; } = new ();
    public int WriterId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public record CreateBookSeriesModel(string Name,
    List<int> BookIds,
    int WriterId);

public interface IBookSeriesManager
{
    Task<BookSeriesModel> CreateBookSeriesAsync(CreateBookSeriesModel model);
    Task<BookSeriesModel> UpdateBookSeriesAsync(int id, CreateBookSeriesModel model);
    Task<bool> DeleteBookSeriesByIdAsync(int id);
    Task<BookSeriesModel> GetBookSeriesByNameAsync(string name);
    Task<BookSeriesModel> GetBookSeriesByWriterIdAsync(int id);
    Task<BookSeriesModel> GetBookSeriesByBookIdAsync(int id);
}
