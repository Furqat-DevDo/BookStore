using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;

namespace Books.Manage.Repositories;

public class BookSeriesRepository : GenericRepository<BookSeries, BookDbContext>, 
    IBookSeriesRepository
{
    public BookSeriesRepository(BookDbContext tContext) : base(tContext)
    {
    }
}
