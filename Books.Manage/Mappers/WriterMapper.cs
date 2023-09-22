using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Mappers;

public class WriterMapper : IWriterMapper
{
    public Writer ToEntity(CreateWriterModel model)
    {
        var writer = new Writer
        {
            FullName = model.FullName
        };
        return writer;
    }

    public WriterModel ToModel(Writer entity)
    {
        var model = new WriterModel
        {
            Id = entity.Id,
            FullName = entity.FullName,
            CreatedDateTime = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate,
        };
        return model;
    }

    public Writer Update(Writer book, CreateWriterModel model)
    {
        book.Id = model.Id;
        book.FullName = model.FullName;

        return book;
    }
}
