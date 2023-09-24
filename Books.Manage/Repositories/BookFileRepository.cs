using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;

namespace Books.Manage.Repositories;

public class BookFileRepository : GenericRepository<BookFile,BookDbContext>, IBookFileRepository
{

    public BookFileRepository(BookDbContext tContext) : base(tContext)
    {
    }

    public async Task<bool> DeleteBookFileAsync(long id)
    {
        var book = await _tContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book is null) return false;

        var bookFile = await _tContext.BookFiles.FirstOrDefaultAsync(f => f.BookId == book.Id);
        if (bookFile is null) return false;

        bookFile.IsDeleted = true;
        File.Delete(bookFile.Path);

        _tContext.BookFiles.Update(bookFile);
        return await _tContext.SaveChangesAsync() > 0;
    }

    public async Task<BookFile?> GetBookFileAsync(long id)
    {
        var book = await _tContext.Books.FirstOrDefaultAsync(b => b.Id == id)
                   ?? throw new NotFoundException(nameof(Book));
        
        return await _tContext.BookFiles.FirstOrDefaultAsync(f => f.BookId == book.Id);
        
    }
}
