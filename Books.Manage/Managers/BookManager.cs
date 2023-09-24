using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Managers;

public class BookManager : IBookManager
{
    private readonly ILogger<BookManager> _logger;
    private readonly IGuardian _guardian;
    private readonly IGenericMapper<CreateBookModel,Book,BookModel> _mapper;
    private readonly IGenericRepository<Book, BookDbContext> _repository;

    public BookManager(ILogger<BookManager> logger,
        IGuardian guardian,
        IGenericMapper<CreateBookModel,Book,BookModel> mapper,
        IGenericRepository<Book, BookDbContext> repository)
    {
        _logger = logger;
        _guardian = guardian;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<BookModel> CreateBookAsync(CreateBookModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var entity = await _repository.AddAsync(
            _mapper.ToEntity(model));

        return _mapper.ToModel(entity);
    }

    public async Task<BookModel> UpdateBookAsync(int id, CreateBookModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var book = await _repository.GetAsync(b => b.Id == id);
        if (book is null)
        {
            _logger.LogWarning("Book Not found.");
            throw new NotFoundException(nameof(book));
        }

        var entity = await _repository.UpdateAsync(
            _mapper.Update(book, model));

        return _mapper.ToModel(entity);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        return await _repository.DeleteAsync(id);
    }

    public async Task<BookModel> GetBookByIdAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var book = await _repository.GetAsync(b => b.Id == id);

        if (book is not null) return _mapper.ToModel(book);

        _logger.LogWarning("Book Not Found.");
        throw new NotFoundException(nameof(book));

    }

    public async Task<BookModel> GetBookByNameAsync(string name)
    {
        await _guardian.GuardAgainstNullOrEmptyString(name);

        var book = await _repository.GetAsync(b => b.Name.Contains(name,
            StringComparison.CurrentCultureIgnoreCase));

        if (book is not null) return _mapper.ToModel(book);

        _logger.LogWarning("Book Not Found");
        throw new NotFoundException(nameof(book));

    }

    public async Task<BookModel> GetBookByWriterId(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var book = await _repository.GetAsync(b => b.WriterId == id);

        if (book is not null) return _mapper.ToModel(book);

        _logger.LogWarning("Book not Found.");
        throw new NotFoundException(nameof(book));

    }


    public async Task<IEnumerable<BookModel>> GetBooksAsync()
    {
        var books = await _repository.GetAllAsync();

        return !books.Any() ? Enumerable.Empty<BookModel>()
            : books.AsEnumerable().Select(_mapper.ToModel);
    }

}