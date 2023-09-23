namespace Books.Manage.Managers.Abstractions;

public class GenreModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public record CreateGenreModel(string Name);

public interface IGenreManager
{
    Task<GenreModel> CreateGenreAsync(CreateGenreModel model);
    Task<GenreModel> UpdateGenreAsync(int id, CreateGenreModel model);
    Task<bool> DeleteGenreAsync(int id);
    Task<GenreModel> GetGenreByIdAsync(int id);
    Task<GenreModel> GetGenreByNameAsync(string name);
    Task<IEnumerable<GenreModel>> GetGenresAsync();
}