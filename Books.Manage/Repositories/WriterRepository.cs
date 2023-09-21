using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Repositories
{
    public class WriterRepository : GenericRepository<Writer, BookDbContext>, IWriterRepository
    {
        public WriterRepository(BookDbContext tContext) : base(tContext)
        {
        }
    }
}
