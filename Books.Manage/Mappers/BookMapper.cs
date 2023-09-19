using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class BookMapper  : IBookMapper
{
    public Book ToEntity(CreateBookModel model)
    {
       var book =  new Book
        {
          Name = model.Name,
          WriterId = model.WriterId,
          FilePath = model.FilePath,
          Description = model.Description,
        };

       if (model.Genres is not null && model.Genres.Any())
       {
           book.Genres = model.Genres.Select(g => new Genre
           {
             Id = g.Id,
             Name = g.Name,
           }).ToList();
       }
       return book;
    }

    public BookModel ToModel(Book entity)
    {
        var model  = new BookModel
        {
            Id = entity.Id,
            Name = entity.Name,
            FilePath = entity.FilePath,
            WriterId = entity.WriterId,
            Description = entity.Description,
            CreatedDateTime = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate

        };

        if (entity.Genres is not null && entity.Genres.Any())
        {
            model.Genres = entity.Genres
                .Select(g => new GenreModel(
                    g.Id,
                    g.Name))
                .ToList();
        }

        return model;
    }

    public Book Update(Book book, CreateBookModel model)
    {
        book.Description = model.Description;
        book.FilePath = model.FilePath;
        book.WriterId = model.WriterId;

        if (model.Genres is not null && model.Genres.Any())
        {
             //TODO IGenre Mapperdan Update Methodini ishlatish.
        }

        return book;
    }
}