using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Managers;

public class BookGenreManager : IBookGenreManager
{
    private readonly ILogger<BookGenreManager> _logger;
    private readonly IGuardian _guardian;
    private readonly IGenericMapper<CreateBookGenreModel,BookGenre,BookGenreModel> _bookGenreMapper;
    private readonly IBookGenreRepository _repository;

    public BookGenreManager(ILogger<BookGenreManager> logger,
        IGuardian guardian,
        IGenericMapper<CreateBookGenreModel,BookGenre,BookGenreModel> bookGenreMapper,
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

        var IsExist = await _repository
            .GetAsync(g =>
            g.GenreId == model.GenreId &&
            g.BookId == model.BookId);

        if(IsExist is not null)
        {
            _logger.LogError("The Book Genre is allready exist.");
            throw new ValidationException(nameof(IsExist));
        }

        var entity = await _repository
            .AddAsync(_bookGenreMapper.ToEntity(model));

        return _bookGenreMapper.ToModel(entity);
    }

    public async Task<bool> DeleteBookGenreAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var check = await _repository.GetAsync(g => g.Id == id);

        if (check is null) return false;
        
        return await _repository.DeleteAsync(id);
    }

    public async  Task<IEnumerable<BookGenreModel>> GetByGenreIdAsync(int id)
    {
        var genres = await _repository.GetAllAsync(bg => bg.GenreId == id);

        return await genres.AnyAsync() ? 
            genres.Select(bg => _bookGenreMapper.ToModel(bg))
            : Enumerable.Empty<BookGenreModel>();
    }

    public async Task<IEnumerable<BookGenreModel>> GetByBookIdAsync(int id)
    {
        var genres = await _repository.GetAllAsync(bg => bg.BookId == id);

        return await genres.AnyAsync() ? 
            genres.Select(bg => _bookGenreMapper.ToModel(bg))
            : Enumerable.Empty<BookGenreModel>();
    }

}
