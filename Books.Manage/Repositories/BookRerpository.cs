using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;

namespace Books.Manage.Repositories;

public class BookRerpository : GenericRepository<Book,BookDbContext>,IBookRepository
{

    public BookRerpository(BookDbContext dbConetxt)  : base(dbConetxt)
    {}

    public override Task<bool> DeleteAsync(long Id)
    {
        return base.DeleteAsync(Id);
    }
}