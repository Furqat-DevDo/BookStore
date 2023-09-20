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

        var entity = await _seriesRepository
            .CreateBookSeries(_mapper.Enter(model));

        return _mapper.ToModel(entity);
    }

    public async Task<bool> DeleteBookSeriesByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        return await _seriesRepository.DeleteById(id);
    }

    public async Task<BookSeriesModel> GetBookSeriesByBookIdAsync(int id)
    {
        _guardian.GuardAgainstZero(id);
        _guardian.GuardAgainstMinus(id);

        var book = await _seriesRepository
            .GetBookSeriesByFilter(s => s.BookId == id);

        if (book is null)
            throw new BookSeriesNotFoundExcecption(nameof(book));

        return _mapper.ToModel(book);
    }

    public async Task<BookSeriesModel> GetBookSeriesByIdAsync(int id)
    {
        _guardian.GuardAgainstZero(id);
        _guardian.GuardAgainstMinus(id);

        var bookSeries = await _seriesRepository.GetById(id);

        if(bookSeries is null)
            throw new BookSeriesNotFoundExcecption(nameof(bookSeries));

        return _mapper.ToModel(bookSeries);
    }

    public async Task<BookSeriesModel> GetBookSeriesByNameAsync(string name)
    {
        _guardian.GuardAgainstNullOrEmptyString(name);
        
        var series = await _seriesRepository
            .GetBookSeriesByFilter(s => s.Name == name);

        if (series is null)
            throw new BookSeriesNotFoundExcecption(nameof(series));

        return _mapper.ToModel(series);
    }

    public async Task<BookSeriesModel> GetBookSeriesByWriterIdAsync(int id)
    {
        _guardian.GuardAgainstZero(id);
        _guardian.GuardAgainstMinus(id);

        var book = await _seriesRepository
            .GetBookSeriesByFilter(s => s.WriterId == id);

        if (book is null)
            throw new BookSeriesNotFoundExcecption(nameof(book));

        return _mapper.ToModel(book);
    }

    public async Task<BookSeriesModel> UpdateBookSeriesAsync(int id,
        CreateBookSeriesModel model)
    {
        await _guardian.GuardAgainstNull(model);
        var updateBookSeries = await _seriesRepository.GetById(id);

        if (updateBookSeries is null) 
            throw new BookSeriesNotFoundExcecption(nameof(updateBookSeries));

        var entity = await _seriesRepository.UpdateBookSeries(
            _mapper.Update(updateBookSeries,model));

        return _mapper.ToModel(entity);
    }
}
