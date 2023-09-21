using Books.Core.Entities;
using Books.Manage.Helpers.FileHelper;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;


namespace Books.Manage.Mappers;

public class BookFileMapper:IBookFileMapper
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

    public async Task<BookFile> ToEntity(CreateBookFile bookFile)
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
}
