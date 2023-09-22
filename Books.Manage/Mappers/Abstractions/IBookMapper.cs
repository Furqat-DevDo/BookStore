 using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;

namespace Books.Manage.Mappers.Abstractions;

public interface IBookMapper
{
    Book ToEntity(CreateBookModel model);
    BookModel ToModel(Book entity);
    Book Update(Book book, CreateBookModel model);
}