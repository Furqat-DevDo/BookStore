using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class BookMapper  : IGenericMapper<CreateBookModel,Book,BookModel>
{
    public Book ToEntity(CreateBookModel model)
    {
        var book =  new Book
        {
          Name = model.Name,
          WriterId = model.WriterId,
          BodyFileSrc = model.FilePath,
          CoverImageSrc = model.CoverImageSrc,
          Description = model.Description,
        };

       return book;
    }

    public BookModel ToModel(Book entity)
    {
        var model  = new BookModel
        {
            Id = entity.Id,
            Name = entity.Name,
            FilePath = entity.BodyFileSrc,
            WriterId = entity.WriterId,
            Description = entity.Description,
            CreatedDateTime = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate,
            CoverImageSrc = entity.CoverImageSrc
        };

        return model;

    }

    public Book Update(Book book, CreateBookModel model)
    {
        book.Description = model.Description;
        book.BodyFileSrc = model.FilePath;
        book.CoverImageSrc = model.CoverImageSrc;
        book.WriterId = model.WriterId;

        return book;
    }
}