using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class WriterMapper : IGenericMapper<CreateWriterModel,Writer,WriterModel>
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

    public Writer Update(Writer writer, CreateWriterModel model)
    {
        writer.FullName = model.FullName;

        return writer;
    }
}
