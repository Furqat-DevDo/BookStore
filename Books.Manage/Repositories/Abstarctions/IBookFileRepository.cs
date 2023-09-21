
using Books.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookFileRepository
{
    Task<BookFile> GetBookFileAsync(int id);
    Task<BookFile> CreateBookFileAsync(BookFile bookFile);
    Task<bool> DeleteBookFileAsync(int id);
}
