using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class GenreMapper : IGenreMapper
{
    public Genre ToEntity(CreateGenreModel model)
    {
        var genre = new Genre
        {
            Name = model.Name,
            Id = model.Id,

        };
        return genre;
    }

    public GenreModel ToModel(Genre entity)
    {
        var genre = new GenreModel
        {
            Name = entity.Name,
            Id = entity.Id,
            CreatedDateTime = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate
        };
        return genre;

    }

    public Genre Update(Genre genre, CreateGenreModel model)
    {
        genre.Id = model.Id;
        genre.Name = model.Name;
        return genre;
    }
}
