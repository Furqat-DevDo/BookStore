using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;

namespace Books.Manage.Mappers.Abstractions;

public interface IBookFileMapper
{
    BookFileDto MapToDto(BookFile bookFile);
    BookFile MapToEntity(BookFileDto bookFileDto);
}
