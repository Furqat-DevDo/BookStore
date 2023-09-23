using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class BookGenreMapper : IGenericMapper<CreateBookGenreModel,BookGenre,BookGenreModel>
{
    public BookGenre ToEntity (CreateBookGenreModel model)
    {
        var bookGenre = new BookGenre
        {
            BookId = model.BookId,
            GenreId = model.GenreId,
        };
        return bookGenre;
    }

    public BookGenreModel ToModel(BookGenre model)
    {
        var bookGenre = new BookGenreModel
        {
            GenreId = model.GenreId,
            BookId = model.BookId,
            CreatedDate = model.CreatedDate,
            UpdatedDate = model.UpdatedDate,
        };
        return bookGenre;
    }

    public BookGenre Update(BookGenre book, CreateBookGenreModel model)
    {
        book.BookId = model.BookId;
        book.GenreId = model.GenreId;

        return book;
    }
}
