using Books.Core.Entities;


namespace Books.Manage.Repositories.Abstarctions;

public interface IBookFileRepository
{
    Task<BookFile> GetBookFileAsync(int id);
    Task<BookFile> CreateBookFileAsync(BookFile bookFile);
    Task<bool> DeleteBookFileAsync(int id);
}
