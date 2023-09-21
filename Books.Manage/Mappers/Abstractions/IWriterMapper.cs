using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Mappers.Abstractions;

public interface IWriterMapper
{
    Writer ToEntity(CreateWriterModel model);
    WriterModel ToModel(Writer entity);
    Writer Update(Writer book, CreateWriterModel model);
}
