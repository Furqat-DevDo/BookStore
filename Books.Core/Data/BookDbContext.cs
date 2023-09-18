using Books.Core.Configurations;
using Books.Core.Entities;
using Books.Core.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Books.Core.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookSeries> BookSeries { get; set; }
    public DbSet<BookFile> BookFiles { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new BookGenreConfiguration().Configure(modelBuilder.Entity<BookGenre>());
        new BookSeriesConfiguration().Configure(modelBuilder.Entity<BookSeries>());
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ModifyTrackedEntites(ChangeTracker.Entries());
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void ModifyTrackedEntites(IEnumerable<EntityEntry> entries)
    {
        foreach(var entry in entries)
        {
            if(entry.Entity is BaseEntity entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.UtcNow;
                    entity.UpdatedDate = null;
                }
                else if (entry.State == EntityState.Modified)
                    entity.UpdatedDate = DateTime.UtcNow;
            }
        }
    }
}