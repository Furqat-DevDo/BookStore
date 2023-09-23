using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Logging;


namespace Books.Manage.Managers;

public class GenreManager : IGenreManager
{
    private readonly ILogger<GenreManager> _logger;
    private readonly IGuardian _guardian;
    private readonly IGenreMapper _mapper;
    private readonly IGenericRepository<Genre, BookDbContext> _repository;
    public GenreManager(
        ILogger<GenreManager> logger,
        IGuardian guardian,
        IGenreMapper mapper,
        IGenreRepository repository)
    {
        _logger = logger;
        _guardian = guardian;
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<GenreModel> CreateGenreModelAsync(CreateGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var entity = await _repository.AddAsync(
            _mapper.ToEntity(model));

        return _mapper.ToModel(entity);
    }

    public async Task<bool> DeleteGenreAsync(int Id)
    {
        await _guardian.GuardAgainstZero(Id);
        await _guardian.GuardAgainstMinus(Id);

        return await _repository.DeleteAsync(Id);
    }

    public async Task<IEnumerable<GenreModel>> GetGenreAsync()
    {
        var books = await _repository.GetAllAsync();

        return !books.Any() ? Enumerable.Empty<GenreModel>()
            : books.AsEnumerable().Select(_mapper.ToModel);
    }

    public async Task<GenreModel> GetGenreByIdAsync(int Id)
    {
        await _guardian.GuardAgainstZero(Id);
        await _guardian.GuardAgainstMinus(Id);

        var genre = await _repository.GetAsync(b => b.Id == Id);

        if (genre is null)
        {
            _logger.LogWarning("Genre Not Found.");
            throw new BookNotFoundException(nameof(genre));
        }

        return _mapper.ToModel(genre);
    }

    public async Task<GenreModel> GetGenreByNameAsync(string Name)
    {
        await _guardian.GuardAgainstNullOrEmptyString(Name);

        var genre = await _repository.GetAsync(b => b.Name.Contains(Name,
            StringComparison.CurrentCultureIgnoreCase));

        if (genre is null)
        {
            _logger.LogWarning("Book Not Found");
            throw new BookNotFoundException(nameof(genre));
        }

        return _mapper.ToModel(genre);
    }

    public async Task<GenreModel> UpdateGenreModelAsync(int Id, CreateGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var genre = await _repository.GetAsync(b => b.Id == Id);
        if (genre is null)
        {
            _logger.LogWarning("Book Not found.");
            throw new BookNotFoundException(nameof(genre));
        }

        var entity = await _repository.UpdateAsync(
            _mapper.Update(genre, model));

        return _mapper.ToModel(entity);
    }
}
