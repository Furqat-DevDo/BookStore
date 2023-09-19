using Books.Core.Entities;
using System.Linq.Expressions;

namespace Books.Manage.Repositories.Abstarctions;

public interface IBookRepository
{
    Task<Book?> GetById(int id);
    Task<List<Book>> GetAll();
    Task<bool> DeleteById(int id);
    Task<Book> CreateBook(Book model);
    Task<Book> UpdateBook(Book model);
    Task<Book?> GetBookByFilter(Expression<Func<Book, bool>> predicate);
}