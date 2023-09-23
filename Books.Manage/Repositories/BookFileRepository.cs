using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Repositories.Abstarctions;
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

    public async Task<bool> DeleteBookFileAsync(long id)
    {
        var book = await _dbConetxt.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book is null) return false;

        var bookFile = await _dbConetxt.BookFiles.FirstOrDefaultAsync(f => f.BookId == book.Id);
        if (bookFile is null) return false;

        bookFile.IsDeleted = true;
        File.Delete(bookFile.Path);

        _dbConetxt.BookFiles.Update(bookFile);
        return await _dbConetxt.SaveChangesAsync() > 0;
    }

    public async Task<BookFile> GetBookFileAsync(long id)
    {
        var book = await _dbConetxt.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book is null)
        {
            throw new NotFoundException();
        }

        var bookFile = await _dbConetxt.BookFiles.FirstOrDefaultAsync(f => f.BookId == book.Id);
        return bookFile;
    }
}
