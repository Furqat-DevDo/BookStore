using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Manage.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly BookDbContext _dbContext;
    public GenreRepository(BookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Genre> CreateGenre(Genre genre)
    {
        var result = await _dbContext.Genres.AddAsync(genre);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<bool> DeleteById(int id)
    {
        var genre = await _dbContext.Genres.FirstOrDefaultAsync(gen => gen.Id == id);
        if (genre is null) return false;
        genre.IsDeleted = true;
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<List<Genre>> GetAll()
       => await _dbContext.Genres.ToListAsync();

    public async Task<Genre?> GetById(int id)
       => await _dbContext.Genres.FirstOrDefaultAsync(b => b.Id == id);

    public async Task<Genre?> GetGenreByFilter(Expression<Func<Genre, bool>> predicate)
    => await _dbContext.Genres.FirstOrDefaultAsync(predicate);
    

    public async Task<Genre> UpdateGenre(Genre genre)
    {
        var result = _dbContext.Genres.Update(genre);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }
}
