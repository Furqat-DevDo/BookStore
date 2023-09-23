using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;


namespace Books.Manage.Mappers;

public class GenreMapper : IGenericMapper<CreateGenreModel,Genre,GenreModel>
{
    public Genre ToEntity(CreateGenreModel model)
        =>  new Genre
        {
            Name = model.Name,
        };

    

    public GenreModel ToModel(Genre entity)
    {
        var genre = new GenreModel
        {
            Id = entity.Id,
            Name = entity.Name,
            CreatedDateTime = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate
        };

        return genre;
    }

    public Genre Update(Genre genre, CreateGenreModel model)
    {
        genre.Name = model.Name;
        return genre;
    }
}