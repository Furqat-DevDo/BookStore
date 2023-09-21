using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.FileHelper;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Books.Manage.Repositories;

public class BookFileRepository : IBookFileRepository
{
    private readonly BookDbContext _dbConetxt;

    public BookFileRepository(BookDbContext dbConetxt)
    {
        _dbConetxt = dbConetxt;
    }

    public async Task<BookFile> CreateBookFileAsync(BookFile bookFile)
    {
        var result = await _dbConetxt.BookFiles.AddAsync(bookFile);
        await _dbConetxt.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteBookFileAsync(int id)
    {
        var book = await _dbConetxt.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book is null) return false;

        var bookFile = await _dbConetxt.BookFiles.FirstOrDefaultAsync(f => f.BookId == book.Id);
        if (bookFile is null) return false;

        

        return await _dbConetxt.SaveChangesAsync() > 0;
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
