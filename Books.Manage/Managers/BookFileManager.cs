using Books.Core.Entities;
using Books.Manage.Helpers.FileHelper;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Managers;

public class BookFileManager : IBookFileManager
{
    private readonly ILogger<BookManager> _logger;
    private readonly IGuardian _guardian;
    private readonly IBookFileMapper _mapper;
    private readonly IBookFileRepository _repository;

    public BookFileManager(
        ILogger<BookManager> logger,
        IGuardian guardian,
        IBookFileMapper mapper, 
        IBookFileRepository repository)
    {
        _logger = logger;
        _guardian = guardian;
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<BookFileModel> CreateBookFileAsync(CreateBookFile bookFile)
    {
        await _guardian.GuardAgainstNull(bookFile);

        var book = await _mapper.ToEntity(bookFile);

        var dbResult = await _repository.CreateBookFileAsync(book);
        
        return _mapper.ToModel(dbResult);
    }

    public async Task<bool> DeleteBookFileAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        return await _repository.DeleteBookFileAsync(id);
    }

    public async Task<(byte[] bytes, string[] fileInfo)> GetBookFileAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var bookFile = await _repository.GetBookFileAsync(id);

        var bytes = await FileHelper.ReadFileAsync(bookFile.Path);
        var fileInfo = new string[] 
        {
            GetContentType(Path.GetExtension(bookFile.Path)),
            Path.GetFileName(bookFile.Path) 
        };

        return new(bytes, fileInfo);
    }

    private static readonly Dictionary<string, string> _contentTypes = new Dictionary<string, string>
    {
        { ".epub", "application/epub" },
        { ".fb2", "application/fb2" },
        { ".mobi", "application/mobi" },
        { ".txt", "application/txt" },
        { ".pdf", "application/pdf" }
    };

    private string GetContentType(string fileExtension)
    {
        return _contentTypes.TryGetValue(fileExtension.ToLower(), out var contentType) ? contentType : "application/octet-stream";
    }
}
