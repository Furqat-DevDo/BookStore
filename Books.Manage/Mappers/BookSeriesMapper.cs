using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class BookSeriesMapper : 
    IGenericMapper<CreateBookSeriesModel,BookSeries,BookSeriesModel>
{
    public BookSeries ToEntity(CreateBookSeriesModel model)
    {
        var bookSeries = new BookSeries
        {
            Name = model.Name,
            WriterId = model.WriterId,
            BookIds = model.BookIds
        };
        return bookSeries;
    }

    public BookSeriesModel ToModel(BookSeries entity)
    {
        var model = new BookSeriesModel
        {
            Id = entity.Id,
            Name = entity.Name,
            WriterId = entity.WriterId,
            BookIds = entity.BookIds,
            CreatedDateTime = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate,
        };
        return model;
    }

    public BookSeries Update(BookSeries entity, CreateBookSeriesModel seriesModel)
    {
        entity.Name = seriesModel.Name;
        entity.WriterId = seriesModel.WriterId;
        entity.BookIds = seriesModel.BookIds;

        return entity;
    }
}
