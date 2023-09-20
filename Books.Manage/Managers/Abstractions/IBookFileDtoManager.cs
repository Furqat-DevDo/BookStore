
using Books.Core.Entities;

namespace Books.Manage.Managers.Abstractions;

public interface IBookFileDtoManager
{
    Task<BookFileDto> CreateBookFileAsync(CreateBookFile bookFile);
    Task<BookFileDto> UpdateBookFileAsync(int id, CreateBookFile bookFile);
    Task<bool> DeleteBookFileAsync(int id);
    Task<BookFileDto> GetBookFileByIdAsync(int id);
    Task<List<BookFileDto>> GetBookFilesAsync();
}
public class BookFileDto
{
    public new Guid Id { get; set; }
    public required string Path { get; set; }
    public float Size { get; set; }
    public int BookId { get; set; }
    public virtual Book? Book { get; set; }
    public required string FileExtension { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set;}
}
public record CreateBookFile(Guid Id,int BookId, string Path, string FileExtension);
