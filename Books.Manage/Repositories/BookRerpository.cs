using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.Manage.Repositories;

public class BookRerpository : GenericRepository<Book,BookDbContext>, IBookRepository
{
    private readonly IBookFileRepository _bookFileRepository;
    public BookRerpository(BookDbContext dbConetxt,
        IBookFileRepository repository)  : base(dbConetxt) 
    {
        _bookFileRepository = repository;
    }

    public override async Task<bool> DeleteAsync(long Id)
    {
        if(! (await base.DeleteAsync(Id)))
        {
            throw new BookNotFoundException();
        }

        return await _bookFileRepository.DeleteBookFileAsync(Id);
    }
}