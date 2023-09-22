using Books.Core.Entities;


namespace Books.Manage.Repositories.Abstarctions;

public interface IBookFileRepository
{
    Task<BookFile> GetBookFileAsync(long id);
    Task<BookFile> CreateBookFileAsync(BookFile bookFile);
    Task<bool> DeleteBookFileAsync(long id);
}
