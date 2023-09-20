using Books.Core.Data;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Managers;

public class GenreManager : IGenreManager
{
    private readonly ILogger<GenreModel> _logger;
    private readonly BookDbContext _dbContext;
    private readonly IGuardian _guardian;
    private readonly IGenreMapper _mapper;
    private readonly IGenreRepository _repository;

    public GenreManager(ILogger<GenreModel> logger,
        BookDbContext dbContext,
        IGuardian guardian,
        IGenreMapper mapper,
        IGenreRepository repository)
    {
        _dbContext = dbContext;
        _logger = logger;
        _guardian = guardian;
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<GenreModel> CreateGenreAsync(CreateGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);
        _mapper.ToEntity(model);
        var entity = await _repository.CreateGenre(_mapper.ToEntity(model));
        return _mapper.ToModel(entity);
    }

    public Task<bool> DeleteGenreAsync(int id)
    {
        _guardian.GuardAgainstZero(id);
        _guardian.GuardAgainstMinus(id);
        return _repository.DeleteById(id);
    }

    public async Task<List<GenreModel>> GetAllGenreAsync()
    {
        var genre = await _repository.GetAll();
        return !genre.Any() ? new List<GenreModel>()
            :genre.Select(_mapper.ToModel).ToList();
    }

    public async Task<GenreModel> GetGenreByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);
        var genre = await _repository.GetById(id);
        if (genre is null) throw new GenreNotFoundException(nameof(genre));
        return _mapper.ToModel(genre);
    }

    public async Task<GenreModel> GetGenreNameAsync(string name)
    {
        await _guardian.GuardAgainstNullOrEmptyString(name);
        var genre = await _repository.GetGenreByFilter(b => b.Name == name);
        if (genre is null) throw new GenreNotFoundException(nameof(genre));
        return _mapper.ToModel(genre);
    }

    public async Task<GenreModel> UpdateGenreAsync(int id, CreateGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);
        _mapper.ToEntity(model);
        var genre = await _repository.GetById(id);
        if (genre is null) throw new GenreNotFoundException(nameof(genre));
        var entity = await _repository.UpdateGenre(_mapper.ToEntity(model));
        return _mapper.ToModel(entity);
    }
}
