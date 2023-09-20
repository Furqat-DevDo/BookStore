using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.FileHelper;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.AspNetCore.Http;


namespace Books.Manage.Repositories;

public class BookFileRepository : IBookFileRepository
{
    private readonly BookDbContext _dbConetxt;
    private static FileHelper _helper;

    public BookFileRepository(BookDbContext dbConetxt, FileHelper helper)
    {
        _dbConetxt = dbConetxt;
        _helper = helper;
    }

    public async Task<int> CreateBookFileAsync(BookFile bookFile, IFormFile fromfile)
    {
         
    }

    public Task<bool> DeleteBookFileAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BookFile> GetBookFileAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<BookFile>> GetBookFilesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateBookFileAsync(int id, BookFile bookFile)
    {
        
    }
}
