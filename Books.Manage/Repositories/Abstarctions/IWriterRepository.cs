using Books.Core.Data;
using Books.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Repositories.Abstarctions;

public interface IWriterRepository : IGenericRepository<Writer, BookDbContext>
{

}
