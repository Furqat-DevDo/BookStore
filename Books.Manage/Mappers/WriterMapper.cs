using System.Globalization;
using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class WriterMapper : IGenericMapper<CreateWriterModel,Writer,WriterModel>
{
    public Writer ToEntity(CreateWriterModel model)
    {
        var date = DateOnly.ParseExact(model.Birthdate,"MM/dd/yyyy",null);

        var writer = new Writer
        {
            FullName = model.FullName,
            BirthDate= date,
            WriterImage=model.WriterImage,
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
            WriterImage = entity.WriterImage
        };
        return model;
    }

    public Writer Update(Writer writer, CreateWriterModel model)
    {
        writer.FullName = model.FullName;
        writer.WriterImage = model.WriterImage;

        return writer;
    }
}
