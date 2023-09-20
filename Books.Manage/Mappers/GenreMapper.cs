

using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public  class GenreMapper : IGenreMapper
{
    public Genre ToEntity(CreateGenreModel model)
    => new Genre
    {
        Name = model.Name,
        Id = model.Id,
    };

    public GenreModel ToModel(Genre entity)
    {
        var genre = new GenreModel
        (entity.Id, entity.Name);
        return genre; 
        
    }

    public Genre Update(Genre genre, CreateGenreModel model)
    {
        
        genre.Name = model.Name;
        genre.Id = model.Id;
        return genre;
    }
}
