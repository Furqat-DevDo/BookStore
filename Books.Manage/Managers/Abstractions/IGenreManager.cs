namespace Books.Manage.Managers.Abstractions;

public record GenreModel(int Id, string Name);
public record CreateGenreModel(int Id, string Name );

public interface IGenreManager
{
    Task<GenreModel> CreateGenreAsync(CreateGenreModel model);
    Task<GenreModel> UpdateGenreAsync(int id,CreateGenreModel model);
    Task<bool> DeleteGenreAsync(int id);
    Task<GenreModel> GetGenreByIdAsync(int id);
    Task<GenreModel> GetGenreNameAsync(string name);
    Task<List<GenreModel>> GetAllGenreAsync();
}

