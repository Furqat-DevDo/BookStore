using Books.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Books.Manage.Managers.Abstractions;

public interface IBookFileManager
{
    Task<BookFileModel> CreateBookFileAsync(CreateBookFile bookFile);
    Task<bool> DeleteBookFileAsync(int id);
    Task<BookFileModel> GetBookFileInfoAsync(int id);
    Task<(byte[] bytes, string[] fileInfo)> DownloadBookFileAsync(int id);
}
public class BookFileModel
{
    public new Guid Id { get; set; }
    public required string Path { get; set; }
    public float Size { get; set; }
    public int BookId { get; set; }
    public required string FileExtension { get; set; }
    public DateTime CreatedDate { get; set; }
}

public record CreateBookFile(int BookId, IFormFile File);
