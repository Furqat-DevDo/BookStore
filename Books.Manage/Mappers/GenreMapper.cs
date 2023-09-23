using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Mappers;

public class GenreMapper : IGenreMapper
{
    public Genre ToEntity(CreateGenreModel model)
    {
        var genre = new Genre
        {
            Name = model.Name,
        };

        if (model.Books is not null && model.Books.Any())
        {
            genre.Books = model.Books.Select(g => new Book
            {
                Id = g.Id,
                Name = g.Name,
                WriterId = g.WriterId,
                FilePath = g.FilePath,
                Description = g.Description,
            }).ToList();
        }
        return genre;
    }

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
        genre.Id = model.Id;
        genre.Name = model.Name;

        return genre;
    }
}