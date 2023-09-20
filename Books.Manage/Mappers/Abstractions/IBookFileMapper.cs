using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;

namespace Books.Manage.Mappers.Abstractions;

public interface IBookFileMapper
{
    BookFileDto MapToDto(CreateBookFile bookFile);
    BookFileDto MapToEntity(BookFile bookFileDto);
    BookFile Update(BookFile bookFile, CreateBookFile bookFileModel);
}
