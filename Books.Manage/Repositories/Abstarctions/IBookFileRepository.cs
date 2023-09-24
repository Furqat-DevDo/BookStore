using Books.Core.Data;
using Books.Core.Entities;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookFileRepository : IGenericRepository<BookFile,BookDbContext>
{
    Task<BookFile?> GetBookFileAsync(long id);
    Task<bool> DeleteBookFileAsync(long id);
}
