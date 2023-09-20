using Books.Core.Entities;
using System.Linq.Expressions;

namespace Books.Manage.Repositories.Abstarctions;

public interface IGenreRepository
{
    Task<Genre?> GetById(int id);
    Task<List<Genre>> GetAll();
    Task<bool> DeleteById(int id);
    Task<Genre> CreateGenre(Genre genre);
    Task<Genre> UpdateGenre(Genre genre);
    Task<Genre?> GetGenreByFilter(Expression<Func<Genre,bool>> predicate);
}
