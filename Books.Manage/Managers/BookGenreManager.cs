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
    private readonly IBookGenreMapper _bookGenreMapper;
    private readonly IBookGenreRepository _repository;

    public BookGenreManager(ILogger<BookGenreManager> logger,
        IGuardian guardian,
        IBookGenreMapper bookGenreMapper,
        IBookGenreRepository repository)
    {
        _logger = logger;
        _guardian = guardian;
        _bookGenreMapper = bookGenreMapper;
        _repository = repository;
    }
    public async Task<BookGenreModel> CreateBookGenreAsync(CreateBookGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var check = await _repository
            .GetAllAsync(g =>
            g.GenreId == model.GenreId &&
            g.BookId == model.BookId);

        if(check is null)
        {
            _logger.LogWarning("Invalid data");
            throw new BaseInvalidDataException(nameof(check));
        }

        var entity = await _repository
            .AddAsync(_bookGenreMapper.ToEntity(model));

        return _bookGenreMapper.ToModel(entity);
    }

    public async Task<bool> DeleteBookGenreAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var check = await _repository.GetAsync(g => g.Id == id);

        if (check is null)
        {
            _logger.LogWarning("BookGenre Not found.");
            throw new BookGenreNotFoundException(nameof(check));
        }

        return await _repository.DeleteAsync(id);
    }

    public async Task<BookGenreModel> GetBookGenreByBookIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookGenre = await _repository
            .GetAsync(s => s.BookId == id);

        if (bookGenre is null)
        {
            _logger.LogWarning("BookGenre Not found.");
            throw new BookGenreNotFoundException(nameof(bookGenre));
        }

        return _bookGenreMapper.ToModel(bookGenre);
    }

    public async Task<BookGenreModel> GetBookGenreByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookGenre = await _repository
            .GetAsync(s => s.Id == id);

        if (bookGenre is null)
        {
            _logger.LogWarning("BookGenre Not found.");
            throw new BookGenreNotFoundException(nameof(bookGenre));
        }

        return _bookGenreMapper.ToModel(bookGenre);
    }

    public async Task<BookGenreModel> GetBookGenreByGenreIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookGenre = await _repository
            .GetAsync(s => s.GenreId == id);

        if (bookGenre is null)
        {
            _logger.LogWarning("BookGenre Not found.");
            throw new BookGenreNotFoundException(nameof(bookGenre));
        }

        return _bookGenreMapper.ToModel(bookGenre);
    }

    public async Task<IEnumerable<BookGenreModel>> GetBookGenresAsync()
    {
        var books = await _repository.GetAllAsync();

        return !books.Any() ? Enumerable.Empty<BookGenreModel>()
            : books.AsEnumerable().Select(_bookGenreMapper.ToModel);
    }

    public async Task<BookGenreModel> UpdateBookGenreAsync(int id, CreateBookGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var updateBookGenre = await _repository.GetAsync(g => g.Id == id);

        var check = _repository.GetAsync(g =>
        g.Id == id &&
        g.BookId == model.BookId &&
        g.GenreId == model.GenreId);

        if (check is null || updateBookGenre is null)
        {
            _logger.LogWarning("BookGenre Not Found ");
            throw new BookNotFoundException(nameof(check));
            throw new BookGenreNotFoundException(nameof(check));
            throw new GenreNotFoundException(nameof(check));
        }

        var entity = await _repository.UpdateAsync(
            _bookGenreMapper.Update(updateBookGenre, model));

        return _bookGenreMapper.ToModel(entity);
    }
}
