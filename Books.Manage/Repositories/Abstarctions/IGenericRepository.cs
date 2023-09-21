using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Books.Manage.Repositories.Abstarctions;

public interface IGenericRepository<T, TContext>
    where T : class
    where TContext : DbContext
{
    Task<IQueryable<T>>GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(long Id);
    Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
}