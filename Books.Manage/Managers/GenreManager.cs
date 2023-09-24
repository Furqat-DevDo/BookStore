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
    private readonly ILogger<GenreModel> _logger;
    private readonly IGuardian _guardian;
    private readonly IGenericMapper<CreateGenreModel,Genre,GenreModel> _genreMapper;
    private readonly IGenreRepository _genreRepository;

    public GenreManager(ILogger<GenreModel> logger,
        IGuardian guardian,
        IGenericMapper<CreateGenreModel,Genre,GenreModel> genreMapper,
        IGenreRepository genreRepository)
    {
        _logger = logger;
        _guardian = guardian;
        _genreMapper = genreMapper;
        _genreRepository = genreRepository;
    }
    public async Task<GenreModel> CreateGenreAsync(CreateGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var entity = await _genreRepository.AddAsync(
            _genreMapper.ToEntity(model));

        return _genreMapper.ToModel(entity);
    }

    public async Task<bool> DeleteGenreAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var check = await _genreRepository.GetAsync(g => g.Id == id);

        if (check is not null) return await _genreRepository.DeleteAsync(id);

        _logger.LogWarning("Genre Not found.");
        throw new NotFoundException(nameof(check));

    }

    public async Task<GenreModel> GetGenreByIdAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var genre = await _genreRepository
            .GetAsync(s => s.Id == id);

        if (genre is not null) return _genreMapper.ToModel(genre);

        _logger.LogWarning("BookSeries Not found.");
        throw new NotFoundException(nameof(genre));

    }

    public async Task<GenreModel> GetGenreByNameAsync(string name)
    {
        await _guardian.GuardAgainstNullOrEmptyString(name);

        var genres = await _genreRepository
            .GetAsync(s => s.Name.Contains(name,StringComparison.CurrentCultureIgnoreCase));

        if (genres is not null) return _genreMapper.ToModel(genres);

        _logger.LogWarning("Genre Not Found ");
        throw new NotFoundException(nameof(genres));

    }

    public async Task<IEnumerable<GenreModel>> GetGenresAsync()
    {
        var genres = await _genreRepository.GetAllAsync();

        return !genres.Any() ? Enumerable.Empty<GenreModel>()
            : genres.AsEnumerable().Select(_genreMapper.ToModel);
    }

    public async Task<GenreModel> UpdateGenreAsync(int id, CreateGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);
        await _guardian.GuardAgainstZeroAndMinus(id);

        var genre = await _genreRepository.GetAsync(g => g.Id == id);

        if (genre is null)
        {
            _logger.LogWarning("Genre Not Found ");
            throw new NotFoundException(nameof(Genre));
        }

        var entity = await _genreRepository.UpdateAsync(
            _genreMapper.Update(genre, model));

        return _genreMapper.ToModel(entity);
    }
}