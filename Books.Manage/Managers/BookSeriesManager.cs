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
    private readonly IGenericMapper<CreateBookSeriesModel,BookSeries,BookSeriesModel> _mapper;
    private readonly IBookSeriesRepository _seriesRepository;
    private readonly IWriterRepository _writerRepository;
    private readonly IBookRepository _bookRepository;

    public BookSeriesManager(ILogger<BookSeriesManager> logger,
        IGuardian guardian,
        IGenericMapper<CreateBookSeriesModel,BookSeries,BookSeriesModel> mapper,
        IBookSeriesRepository seriesRepository, 
        IWriterRepository writerRepository, 
        IBookRepository bookRepository)
    {
        _logger = logger;
        _guardian = guardian;
        _mapper = mapper;
        _seriesRepository = seriesRepository;
        _writerRepository = writerRepository;
        _bookRepository = bookRepository;
    }
    public async Task<BookSeriesModel> CreateBookSeriesAsync(CreateBookSeriesModel model)
    {
        await _guardian.GuardAgainstNull(model);
        await _guardian.GuardAgainstNullOrEmptyString(model.Name);

        _ = await _writerRepository.GetAsync(w => w.Id == model.WriterId)
                     ?? throw new NotFoundException(nameof(Writer));

       var IsAllExist = await _bookRepository.CheckAllAsync(model.BookIds);

       if (!IsAllExist) throw new NotFoundException(nameof(Book));

        var entity = await _seriesRepository
            .AddAsync(_mapper.ToEntity(model));

        return _mapper.ToModel(entity);
    }

    public async Task<bool> DeleteBookSeriesByIdAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var bookSeries = await _seriesRepository.GetAsync(g => g.Id == id);

        if (bookSeries is not null) return await _seriesRepository.DeleteAsync(id);

        _logger.LogError("BookSeries Not found.");
        throw new NotFoundException(nameof(bookSeries));

    }


    public async Task<BookSeriesModel> GetBookSeriesByBookIdAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var bookSeries = await _seriesRepository
            .GetAsync(s => s.BookIds.Contains(id));

        if (bookSeries is not null) return _mapper.ToModel(bookSeries);

        _logger.LogWarning("BookSeries Not found.");
        throw new NotFoundException(nameof(bookSeries));

    }

    public async Task<BookSeriesModel> GetBookSeriesByNameAsync(string name)
    {
        await _guardian.GuardAgainstNullOrEmptyString(name);
        
        var series = await _seriesRepository
            .GetAsync(s => s.Name.Contains(name,StringComparison.CurrentCultureIgnoreCase));

        if (series is not null) return _mapper.ToModel(series);

        _logger.LogWarning("BookSeries Not Found ");
        throw new NotFoundException(nameof(series));

    }

    public async Task<BookSeriesModel> GetBookSeriesByWriterIdAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var bookSeries = await _seriesRepository
            .GetAsync(s => s.WriterId == id);

        if (bookSeries is not null) return _mapper.ToModel(bookSeries);

        _logger.LogWarning("BookSeries Not Found ");
        throw new NotFoundException(nameof(bookSeries));

    }

    public async Task<BookSeriesModel> UpdateBookSeriesAsync(int id,
        CreateBookSeriesModel model)
    {
        await _guardian.GuardAgainstNull(model);

        _ = await _writerRepository.GetAsync(w=> w.Id == model.WriterId)
            ?? throw new NotFoundException(nameof(Writer));

        var isAllExist = await _bookRepository.CheckAllAsync(model.BookIds);

        if (!isAllExist) throw new NotFoundException(nameof(Book)); 

        var bookSeries = await _seriesRepository.GetAsync(g => g.Id == id)
            ?? throw new NotFoundException(nameof(BookSeries));

        var entity = await _seriesRepository.UpdateAsync(
            _mapper.Update(bookSeries,model));

        return _mapper.ToModel(entity);
    }
}
