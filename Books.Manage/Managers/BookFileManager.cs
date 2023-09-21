using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;

namespace Books.Manage.Managers;

public class BookFileManager : IBookFileManager
{
    private readonly IGuardian _guardian;
    private readonly IBookFileMapper _mapper;
    private readonly IBookFileRepository _repository;

    public BookFileManager(
        IGuardian guardian,
        IBookFileMapper mapper, 
        IBookFileRepository repository)
    {
        _guardian = guardian;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<BookFileModel> CreateBookFileAsync(CreateBookFile bookFile)
    {
        await _guardian.GuardAgainstNull(bookFile);

        var book = await _mapper.ToEntityAsync(bookFile);

        var dbResult = await _repository.CreateBookFileAsync(book);
        
        return _mapper.ToModel(dbResult);
    }

    public async Task<bool> DeleteBookFileAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        return await _repository.DeleteBookFileAsync(id);
    }

    public async Task<(byte[] bytes, string[] fileInfo)> DownloadBookFileAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookFile = await _repository.GetBookFileAsync(id);

        return await _mapper.ToDownloadAsync(bookFile);
    }

    public async Task<BookFileModel> GetBookFileInfoAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookFile = await _repository.GetBookFileAsync(id);

        return _mapper.ToModel(bookFile);
    }
}
