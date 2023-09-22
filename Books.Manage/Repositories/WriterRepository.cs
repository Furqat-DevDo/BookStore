using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;

namespace Books.Manage.Repositories
{
    public class WriterRepository : GenericRepository<Writer, BookDbContext>, IWriterRepository
    {
        public WriterRepository(BookDbContext tContext) : base(tContext)
        {

        }
    }
}
