using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Manage.Repositories;

public class BookRerpository : IBookRepository
{
    private readonly BookDbContext _dbConetxt;

    public BookRerpository(BookDbContext dbConetxt)
    {
        _dbConetxt = dbConetxt;
    }

    public async  Task<Book?> GetById(int id)
        => await  _dbConetxt.Books.FirstOrDefaultAsync(b=>b.Id == id);

    public async Task<List<Book>> GetAll()
        =>  await _dbConetxt.Books.ToListAsync();

    public async  Task<bool> DeleteById(int id)
    {
        var book = await _dbConetxt.Books.FirstOrDefaultAsync(b => b.Id == id);

        if(book is null) return false;

        book.IsDeleted = true;

        return await _dbConetxt.SaveChangesAsync() > 0;
    }

    public async  Task<Book> CreateBook(Book book)
    {
        var result = await _dbConetxt.Books.AddAsync(book);
        await _dbConetxt.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Book> UpdateBook(Book book)
    {
        var result = _dbConetxt.Books.Update(book);
        await _dbConetxt.SaveChangesAsync();

        return result.Entity;
    }

    public async  Task<Book?> GetBookByFilter(Expression<Func<Book, bool>> predicate)
        => await _dbConetxt.Books.FirstOrDefaultAsync(predicate);
}