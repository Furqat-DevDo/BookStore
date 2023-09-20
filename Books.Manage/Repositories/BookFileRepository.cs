using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;

namespace Books.Manage.Repositories;

public class BookFileRepository : IBookFileRepository
{
    private readonly BookDbContext _dbConetxt;

    public Task<BookFile> CreateBookFileAsync(BookFile bookFileDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBookFileAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<BookFile> GetBookFileAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BookFile>> GetBookFilesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BookFile> UpdateBookFileAsync(Guid id, BookFile bookFileDto)
    {
        throw new NotImplementedException();
    }
}
