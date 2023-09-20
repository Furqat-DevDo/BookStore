using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Manage.Repositories;

public class BookSeriesRepository : IBookSeriesRepository
{
    private readonly BookDbContext _dbContext;
    public BookSeriesRepository(BookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<BookSeries> CreateBookSeries(BookSeries model)
    {
        var result = await _dbContext.AddAsync(model);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> DeleteById(int id)
    {
        var bookSeries = await _dbContext.BookSeries.FirstOrDefaultAsync(s => s.Id == id);

        if (bookSeries is null) return false;

        bookSeries.IsDeleted = true;

        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<BookSeries>> GetAll()
        => await _dbContext.BookSeries.ToListAsync();

    public async Task<BookSeries?> GetBookSeriesByFilter(Expression<Func<BookSeries, bool>> predicate)
        => await _dbContext.BookSeries.FirstOrDefaultAsync(predicate);

    public async Task<BookSeries?> GetById(int id)
        => await _dbContext.BookSeries.FirstOrDefaultAsync(s => s.Id == id);

    public async Task<BookSeries> UpdateBookSeries(BookSeries model)
    {
        var updateBookSeries = _dbContext.BookSeries.Update(model);
        await _dbContext.SaveChangesAsync();

        return updateBookSeries.Entity;
    }
}
