using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;

namespace Books.Manage.Repositories;

public class BookRerpository : GenericRepository<Book,BookDbContext>, IBookRepository
{
    private readonly IBookFileRepository _bookFileRepository;
    public BookRerpository(BookDbContext dbConetxt,
        IBookFileRepository repository)  : base(dbConetxt) 
    {
        _bookFileRepository = repository;
    }

    public override async Task<bool> DeleteAsync(long id)
    {
        var book = await _tContext.Books.FirstOrDefaultAsync(b=> b.Id == id);
        if (book is null)  return false;
        book.IsDeleted = true;

        return await _bookFileRepository.DeleteBookFileAsync(id);
    }

    public Task<bool> CheckAllAsync(List<int> modelBookIds)
        => Task.FromResult(modelBookIds.All(id => _tContext.Books.Any(entity => entity.Id == id)));

    
}