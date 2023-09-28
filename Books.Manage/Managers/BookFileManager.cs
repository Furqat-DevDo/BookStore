using Books.Core.Entities;
using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.FileManager;
using Books.Manage.Helpers.Options;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Options;

namespace Books.Manage.Managers;

public class BookFileManager : IBookFileManager
{
    private readonly IGuardian _guardian;
    private readonly IFileManager _fileManager;
    private readonly IBookFileRepository _repository;
    private readonly IOptions<DirectoryOptions> _options;
    private readonly IGenericMapper<CreateBookFileModel,BookFile,BookFileModel> _mapper;

    public BookFileManager(
        IGuardian guardian,
        IBookFileRepository repository, 
        IFileManager fileManager, 
        IOptions<DirectoryOptions> options, 
        IGenericMapper<CreateBookFileModel,BookFile,BookFileModel> mapper)
    {
        _guardian = guardian;
        _repository = repository;
        _fileManager = fileManager;
        _options = options;
        _mapper = mapper;
    }

    public async Task<BookFileModel> CreateBookFileAsync(CreateBookFileModel model)
    {
        var pathes = _options.Value;

        await _guardian.GuardAgainstNull(model);

        var book = await ToEntityAsync(model,pathes.FilesPath);

        var dbResult = await _repository.AddAsync(book);
        
        return _mapper.ToModel(dbResult);
    }

    public async Task<bool> DeleteBookFileAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        return await _repository.DeleteBookFileAsync(id);
    }

    public async Task<(byte[] bytes, string[] fileInfo)> DownloadBookFileAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var bookFile = await _repository.GetBookFileAsync(id);

        if (bookFile is null)
        {
            throw new NotFoundException(nameof(bookFile));
        }

        return await DownloadAsync(bookFile);
    }

    public async Task<BookFileModel> GetBookFileInfoAsync(int id)
    {
        await _guardian.GuardAgainstZeroAndMinus(id);

        var bookFile = await _repository.GetBookFileAsync(id);
        if (bookFile == null)
        {
            throw new NotFoundException(nameof(bookFile));
        }

        return _mapper.ToModel(bookFile);
    }


    public async Task<(byte[] bytes, string[] fileInfo)> DownloadAsync (BookFile bookFile)
    {
        var bytes = await _fileManager.ReadFileAsync(bookFile.Path);
        var fileInfo = new []
        {
            GetContentType(Path.GetExtension(bookFile.Path)),
            Path.GetFileName(bookFile.Path)
        };
        return (bytes, fileInfo);
    }

    public async Task<BookFile> ToEntityAsync(CreateBookFileModel model,string path)
    {
        var (filePath, fileExt, fileId) = await _fileManager.SaveFileAsync(model.File,path);
        return new BookFile
        {
            Id = fileId,
            //BookId = model.BookId,
            Path = filePath,
            Size = model.File.Length,
            FileExtension = fileExt,
            CreatedDate = DateTime.UtcNow
        };
    }

    private static readonly Dictionary<string, string> _contentTypes = new()
    {
        { ".epub", "application/epub" },
        { ".fb2", "application/fb2" },
        { ".mobi", "application/mobi" },
        { ".txt", "application/txt" },
        { ".pdf", "application/pdf" }
    };

    private string GetContentType(string fileExtension)
    {
        return _contentTypes
            .TryGetValue(fileExtension.ToLower(), out var contentType) ? 
            contentType : "application/octet-stream";
    }
}
