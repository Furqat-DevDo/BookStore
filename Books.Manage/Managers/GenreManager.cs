using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
namespace Books.Manage.Managers;

public class GenreManager : IGenreManager
{
    private readonly ILogger<GenreModel> _logger;
    private readonly IGuardian _guardian;
    private readonly IGenreMapper _genreMapper;
    private readonly IGenreRepository _genreRepository;

    public GenreManager(ILogger<GenreModel> logger,
        IGuardian guardian,
        IGenreMapper genreMapper,
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
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var check = await _genreRepository.GetAsync(g => g.Id == id);

        if (check is null)
        {
            _logger.LogWarning("Genre Not found.");
            throw new GenreNotFoundException(nameof(check));
        }

        return await _genreRepository.DeleteAsync(id);
    }

    public async Task<GenreModel> GetGenreByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var genre = await _genreRepository
            .GetAsync(s => s.Id == id);

        if (genre is null)
        {
            _logger.LogWarning("BookSeries Not found.");
            throw new GenreNotFoundException(nameof(genre));
        }

        return _genreMapper.ToModel(genre);
    }

    public async Task<GenreModel> GetGenreByNameAsync(string name)
    {
        await _guardian.GuardAgainstNullOrEmptyString(name);

        var genres = await _genreRepository
            .GetAsync(s => s.Name == name);

        if (genres is null)
        {
            _logger.LogWarning("Genre Not Found ");
            throw new GenreNotFoundException(nameof(genres));
        }

        return _genreMapper.ToModel(genres);
    }

    public async Task<IEnumerable<GenreModel>> GetGenresAsync()
    {
        var books = await _genreRepository.GetAllAsync();

        return !books.Any() ? Enumerable.Empty<GenreModel>()
            : books.AsEnumerable().Select(_genreMapper.ToModel);
    }

    public async Task<GenreModel> UpdateGenreAsync(int id, CreateGenreModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var updateGenre = await _genreRepository.GetAsync(g => g.Id == id);

        var check = _genreRepository.GetAsync(g =>
        g.Id == id &&
        g.Name == model.Name);

        if (check is null || updateGenre is null)
        {
            _logger.LogWarning("Genre Not Found ");
            throw new GenreNotFoundException(nameof(check));
        }

        var entity = await _genreRepository.UpdateAsync(
            _genreMapper.Update(updateGenre, model));

        return _genreMapper.ToModel(entity);
    }
}