
using Books.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookFileRepository
{
    Task<BookFile> GetBookFileAsync(int id);
    Task<ICollection<BookFile>> GetBookFilesAsync();
    Task<int> CreateBookFileAsync(BookFile bookFile, IFormFile formfile);
    Task<bool> UpdateBookFileAsync(int id, BookFile bookFile);
    Task<bool> DeleteBookFileAsync(int id);
}
