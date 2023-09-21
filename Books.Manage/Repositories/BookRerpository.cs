using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Manage.Repositories;

public class BookRerpository : GenericRepository<Book,BookDbContext>,IBookRepository
{
    public BookRerpository(BookDbContext dbConetxt)  : base(dbConetxt) {}

    public override Task<bool> DeleteAsync(long Id)
    {
        return base.DeleteAsync(Id);
    }
}