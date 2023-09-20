using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class BookSeriesMapper : IBookSeriesMapper
{
    public BookSeries Enter(CreateBookSeriesModel model)
    {
        var bookSeries = new BookSeries
        {
            Name = model.Name,
            WriterId = model.WriterId,
            BookId = model.BookId
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
            BookId = entity.BookId,
            CreatedDateTime = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate,
        };
        return model;
    }

    public BookSeries Update(BookSeries entity, CreateBookSeriesModel seriesModel)
    {
        entity.Name = seriesModel.Name;
        entity.WriterId = seriesModel.WriterId;
        entity.BookId = seriesModel.BookId;

        return entity;
    }
}
