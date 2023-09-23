using Microsoft.AspNetCore.Http;

namespace Books.Manage.Helpers.FileManager;

public interface IFileManager
{
    public Task<(string, string, Guid)> SaveFileAsync(IFormFile formFile, string destination);
    public Task<byte[]> ReadFileAsync(string filePath);
}