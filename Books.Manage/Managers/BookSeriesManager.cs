using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Managers;

public class BookSeriesManager : IBookSeriesManager
{
    private readonly ILogger<BookSeriesManager> _logger;
    private readonly IGuardian _guardian;
    private readonly IBookSeriesMapper _mapper;
    private readonly IBookSeriesRepository _seriesRepository;

    public BookSeriesManager(ILogger<BookSeriesManager> logger,
        IGuardian guardian,
        IBookSeriesMapper mapper,
        IBookSeriesRepository seriesRepository)
    {
        _logger = logger;
        _guardian = guardian;
        _mapper = mapper;
        _seriesRepository = seriesRepository;
    }
    public async Task<BookSeriesModel> CreateBookSeriesAsync(CreateBookSeriesModel model)
    {
        await _guardian.GuardAgainstNull(model);
        await _guardian.GuardAgainstNullOrEmptyString(model.Name);

        var check = _seriesRepository.GetAsync(g => 
        g.BookId == model.BookId && 
        g.WriterId == model.WriterId);

        if(check is null)
        {
            _logger.LogWarning("BookSeries Not found.");
            throw new BookNotFoundException(nameof(check));
            throw new WriterNotFoundException(nameof(check));
        }

        var entity = await _seriesRepository
            .AddAsync(_mapper.ToEntity(model));

        return _mapper.ToModel(entity);
    }

    public async Task<bool> DeleteBookSeriesByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var check = await _seriesRepository.GetAsync(g => g.Id == id);

        if (check is null)
        {
            _logger.LogWarning("BookSeries Not found.");
            throw new BookSeriesNotFoundException(nameof(check));
        }

        return await _seriesRepository.DeleteAsync(id);
    }

    public async Task<BookSeriesModel> GetBookSeriesByBookIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookSeries = await _seriesRepository
            .GetAsync(s => s.BookId == id);

        if (bookSeries is null)
        {
            _logger.LogWarning("BookSeries Not found.");
            throw new BookSeriesNotFoundException(nameof(bookSeries));
        }           

        return _mapper.ToModel(bookSeries);
    }

    public async Task<BookSeriesModel> GetBookSeriesByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookSeries = await _seriesRepository.GetAsync(g => g.Id == id);

        if(bookSeries is null)
        {
            _logger.LogWarning("BookSeries Not Found ");
            throw new BookSeriesNotFoundException(nameof(bookSeries));
        }         

        return _mapper.ToModel(bookSeries);
    }

    public async Task<BookSeriesModel> GetBookSeriesByNameAsync(string name)
    {
        await _guardian.GuardAgainstNullOrEmptyString(name);
        
        var series = await _seriesRepository
            .GetAsync(s => s.Name == name);

        if (series is null)
        {
            _logger.LogWarning("BookSeries Not Found ");
            throw new BookSeriesNotFoundException(nameof(series));
        }            

        return _mapper.ToModel(series);
    }

    public async Task<BookSeriesModel> GetBookSeriesByWriterIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookSeries = await _seriesRepository
            .GetAsync(s => s.WriterId == id);

        if (bookSeries is null)
        {
            _logger.LogWarning("BookSeries Not Found ");
            throw new BookSeriesNotFoundException(nameof(bookSeries));
        }

        return _mapper.ToModel(bookSeries);
    }

    public async Task<BookSeriesModel> UpdateBookSeriesAsync(int id,
        CreateBookSeriesModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var updateBookSeries = await _seriesRepository.GetAsync(g => g.Id == id);

        var check = _seriesRepository.GetAsync(g =>
        g.Id == id &&
        g.Name == model.Name &&
        g.BookId == model.BookId &&
        g.WriterId == model.WriterId);

        if (check is null || updateBookSeries is null)
        {
            _logger.LogWarning("BookSeries Not Found ");
            throw new BookSeriesNotFoundException(nameof(check));
            throw new BookNotFoundException(nameof(check));
            throw new WriterNotFoundException(nameof(check));
        }           

        var entity = await _seriesRepository.UpdateAsync(
            _mapper.Update(updateBookSeries,model));

        return _mapper.ToModel(entity);
    }
}
