namespace Books.Manage.Managers.Abstractions;

public record GenreModel 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
public record CreateGenreModel(int Id, string Name);
public interface IGenreManager
{
    Task<GenreModel> CreateGenreModelAsync( CreateGenreModel model);
    Task<GenreModel> UpdateGenreModelAsync(int Id, CreateGenreModel model);
    Task<bool> DeleteGenreAsync(int Id);
    Task<GenreModel> GetGenreByIdAsync(int Id);
    Task<GenreModel> GetGenreByNameAsync(string  Name);
    Task<IEnumerable<GenreModel>> GetGenreAsync();
}