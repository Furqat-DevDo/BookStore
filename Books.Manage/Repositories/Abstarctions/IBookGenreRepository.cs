using Books.Core.Data;
using Books.Core.Entities;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookGenreRepository : IGenericRepository<BookGenre,BookDbContext>
{
}
