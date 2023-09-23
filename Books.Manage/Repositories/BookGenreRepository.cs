

using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;

namespace Books.Manage.Repositories;

public class BookGenreRepository : GenericRepository<BookGenre, BookDbContext>, IBookGenreRepository
{
    public BookGenreRepository(BookDbContext tContext) : base(tContext) { }
    public override Task<bool> DeleteAsync(long Id)
    {
        return base.DeleteAsync(Id);
    }
}
