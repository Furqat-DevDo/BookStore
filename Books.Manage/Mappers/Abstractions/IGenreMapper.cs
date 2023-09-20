using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;

namespace Books.Manage.Mappers.Abstractions;

public interface IGenreMapper
{
    Genre ToEntity(CreateGenreModel model);
    GenreModel ToModel(Genre entity);
    Genre Update(Genre genre, CreateGenreModel model);
}
