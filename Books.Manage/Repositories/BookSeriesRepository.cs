using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Manage.Repositories;

public class BookSeriesRepository : GenericRepository<BookSeries, BookDbContext>, IBookSeriesRepository
{
    public BookSeriesRepository(BookDbContext tContext) : base(tContext)
    {
    }

    public override Task<bool> DeleteAsync(long Id)
    {
        return base.DeleteAsync(Id);
    }
}
