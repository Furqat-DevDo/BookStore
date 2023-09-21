using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;

namespace Books.Manage.Mappers.Abstractions;

public interface IBookFileMapper
{
    BookFileModel ToModel(BookFile book);
    Task<BookFile> ToEntityAsync(CreateBookFile book);
    Task<(byte[] bytes, string[] fileInfo)> ToDownloadAsync(BookFile bookFile);
}
