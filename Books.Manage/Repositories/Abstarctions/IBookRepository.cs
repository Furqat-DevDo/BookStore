using Books.Core.Entities;
using Books.Core.Data;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookRepository : IGenericRepository<Book,BookDbContext>
{
    
}