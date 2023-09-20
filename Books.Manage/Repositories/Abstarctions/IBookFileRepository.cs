
using Books.Core.Entities;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookFileRepository
{
    Task<BookFile> GetBookFileAsync(Guid id);
    Task<ICollection<BookFile>> GetBookFilesAsync();
    Task<BookFile> CreateBookFileAsync(BookFile bookFile);
    Task<BookFile> UpdateBookFileAsync(Guid id, BookFile bookFile);
    Task<bool> DeleteBookFileAsync(Guid id);
}
