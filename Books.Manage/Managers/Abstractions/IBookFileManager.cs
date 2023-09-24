using Microsoft.AspNetCore.Http;

namespace Books.Manage.Managers.Abstractions;

public interface IBookFileManager
{
    Task<BookFileModel> CreateBookFileAsync(CreateBookFileModel model);
    Task<bool> DeleteBookFileAsync(int id);
    Task<BookFileModel> GetBookFileInfoAsync(int id);
    Task<(byte[] bytes, string[] fileInfo)> DownloadBookFileAsync(int id);
}

public record BookFileModel
{
    public Guid Id { get; init; } 
    public required  string Path { get; init; }
    public float Size { get; init; }
    public int BookId { get; init; }
    public required string FileExtension { get; init; }
    public DateTime CreatedDate { get; init; }
}

public record CreateBookFileModel(int BookId, IFormFile File);
