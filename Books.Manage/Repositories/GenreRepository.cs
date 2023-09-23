using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;

namespace Books.Manage.Repositories;

public class GenreRepository : GenericRepository<Genre, BookDbContext>, IGenreRepository
{
    public GenreRepository(BookDbContext tContext) : base(tContext)
    {
    }
}
