using Books.Core.Data;
using Books.Core.Entities;

namespace Books.Manage.Repositories.Abstarctions;

public interface IWriterRepository : IGenericRepository<Writer, BookDbContext>
{

}
