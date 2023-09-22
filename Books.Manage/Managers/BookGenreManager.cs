
using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Managers;

public class BookGenreManager : IBookGenreManager
{
    private readonly ILogger<BookGenreManager> _logger;
    private readonly IGuardian _guardian;
    private readonly IBookGenreMapper _mapper;
    private readonly IGenericRepository<BookGenre, BookDbContext> _repository;

    public BookGenreManager(
        ILogger<BookGenreManager> logger,
        IGuardian guardian,
        IBookGenreMapper mapper,
        IBookGenreRepository repository)
    {
        _logger = logger;
        _guardian = guardian;
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<BookGenreModel> CreateBookGenreAsync(CreateBookGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);
        await _guardian.GuardAgainstNullOrEmptyString(model.BookId);
        var check = _repository.GetAsync(g => g.BookId == model.BookId);
        if (check is null)
        {
            _logger.LogWarning("BookGenre Not Found !");
            throw new BookGenreNotFoundException(nameof(check));
        }
        var entity = await _repository.AddAsync(_mapper.ToEntity(model));
        return _mapper.ToModel(entity);

    }

    public async Task<bool> DeleteBookGenreAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);
        var check = await _repository.GetAsync(g => g.BookId == id);
        if (check is null)
        {
            _logger.LogWarning("BookGenre Not Foun !");
            throw new BookGenreNotFoundException(nameof(check));
        }
        return await _repository.DeleteAsync(id);
    }

    public async Task<BookGenreModel> GetBookGenreByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var check = await _repository.GetAsync(g => g.Id == id);

        if (check is null)
        {
            _logger.LogWarning("BookSeries Not Found ");
            throw new BookGenreNotFoundException(nameof(check));
        }

        return _mapper.ToModel(check);
    }

    public async Task<IEnumerable<BookGenreModel>> GetBookGenresAsync()
    {
        var books = await _repository.GetAllAsync();

        return !books.Any() ? Enumerable.Empty<BookGenreModel>()
            : books.AsEnumerable().Select(_mapper.ToModel);
    }

    public async Task<BookGenreModel> UpdateBookGenreAsync(int id, CreateBookGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var updateBookGenre = await _repository.GetAsync(g => g.BookId == id);

        var check = _repository.GetAsync(g =>
        g.BookId == model.BookId );

        if (check is null || updateBookGenre is null)
        {
            _logger.LogWarning("BookSeries Not Found ");
            throw new BookGenreNotFoundException(nameof(check));
            throw new BookNotFoundException(nameof(check));


        }
        var entity = await _repository.UpdateAsync(
            _mapper.Update(updateBookGenre, model));

        return _mapper.ToModel(entity);
    }
}
