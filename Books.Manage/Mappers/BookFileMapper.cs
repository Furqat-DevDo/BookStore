using Books.Core.Entities;
using Books.Manage.Helpers.FileHelper;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;


namespace Books.Manage.Mappers;

public class BookFileMapper : IBookFileMapper
{
    public BookFileModel ToModel(BookFile book)
    {
        var filemodel = new BookFileModel
        {
            Path = book.Path,
            FileExtension = book.FileExtension,
            Size = book.Size,
            BookId = book.BookId,
            CreatedDate = book.CreatedDate,
        };

        return filemodel;
    }

    public async Task<(byte[] bytes, string[] fileInfo)> ToDownloadAsync(BookFile bookFile)
    {
        var bytes = await FileHelper.ReadFileAsync(bookFile.Path);
        var fileInfo = new string[]
        {
            GetContentType(Path.GetExtension(bookFile.Path)),
            Path.GetFileName(bookFile.Path)
        };
        return (bytes, fileInfo);
    }

    public async Task<BookFile> ToEntityAsync(CreateBookFile bookFile)
    {
        var (filePath, fileExt, fileId) = await FileHelper.SaveFileAsync(bookFile.File);
        return new BookFile
        {
            Id = fileId,
            BookId = bookFile.BookId,
            Path = filePath,
            Size = bookFile.File.Length,
            FileExtension = fileExt,
            CreatedDate = DateTime.UtcNow
        };
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
        return _contentTypes
            .TryGetValue(fileExtension.ToLower(), out var contentType) ? 
            contentType : "application/octet-stream";
    }
}
