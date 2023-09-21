using Books.Core.Data;
using Books.Core.Entities;
using System.Linq.Expressions;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookSeriesRepository : IGenericRepository<BookSeries, BookDbContext>
{
}
