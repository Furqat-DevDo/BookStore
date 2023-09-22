

using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class BookGenreMapper : IBookGenreMapper
{
    public BookGenre ToEntity(CreateBookGenreModel model)
        => new BookGenre
        {
            BookId = model.BookId
        };

    public BookGenreModel ToModel(BookGenre entity)
    {
        var model = new BookGenreModel
        {
            BookId = entity.BookId,
            CreatedDateTime = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate,
        };
        return model;
    }

    public BookGenre Update(BookGenre genre, CreateBookGenreModel model)
    {
        genre.BookId = model.BookId;
        return genre;
    }
}
