using Books.Core.Entities;
using System.Linq.Expressions;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookSeriesRepository
{
    Task<BookSeries?> GetById(int id);
    Task<List<BookSeries>> GetAll();
    Task<bool> DeleteById(int id);
    Task<BookSeries> CreateBookSeries(BookSeries model);
    Task<BookSeries> UpdateBookSeries(BookSeries model);
    Task<BookSeries?> GetBookSeriesByFilter(Expression<Func<BookSeries, bool>> predicate);
}
