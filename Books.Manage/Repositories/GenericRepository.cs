using System.Linq.Expressions;
using Books.Core.Entities.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;

namespace Books.Manage.Repositories;

public abstract class GenericRepository<T,TContext> : 
    IGenericRepository<T, TContext>
    where T : BaseEntity
    where TContext : DbContext
{
    protected TContext _tContext;
    internal DbSet<T> _dbSet;

    protected GenericRepository(TContext tContext)
    {
        _tContext = tContext;
        _dbSet = tContext.Set<T>();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        var entry = await _dbSet.AddAsync(entity);
        await _tContext.SaveChangesAsync();

        return entry.Entity;
    }

    public virtual async Task<bool> DeleteAsync(long Id)
    {
        var entity = await _dbSet.FindAsync(Id);

        if (entity is null) return false; 
        entity.IsDeleted = true;
        return  await _tContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entities = await GetAllAsync(expression);

        if(!entities.Any()) return false;

        await entities.ForEachAsync(e => e.IsDeleted = true);

        return await _tContext.SaveChangesAsync() > 0;
    }

    public virtual async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
    {
        return await Task.FromResult(predicate == null ? _dbSet : _dbSet.Where(predicate));
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.FirstOrDefaultAsync(predicate);
    

    public virtual async Task<T> UpdateAsync(T entity)
    {
        var entry = _tContext.Update(entity);
        await _tContext.SaveChangesAsync();

        return entity;
    }
}