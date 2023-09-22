using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;

namespace Books.Manage.Mappers.Abstractions;

public interface IBookGenreMapper
{
    BookGenre ToEntity(CreateBookGenreModel model);
    BookGenreModel ToModel(BookGenre entity);
    BookGenre Update(BookGenre genre,CreateBookGenreModel model);
}
