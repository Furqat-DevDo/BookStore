using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Books.Manage.Mappers.Abstractions.IBookFileMapper;

namespace Books.Manage.Mappers;

public class BookFileMapper:IBookFileMapper
{
    public BookFileDto MapToDto(BookFile bookFile)
    {
        if (bookFile is null)
        {
            return null;
        }

        return new BookFileDto
        {
            Id = bookFile.Id,
            Path = bookFile.Path,
            Size = bookFile.Size,
            FileExtension = bookFile.FileExtension,

        };
    }

    public BookFile MapToEntity(BookFileDto bookFileDto)
    {
        if (bookFileDto is null)
        {
            return null;
        }

        return new BookFile
        {
            Id = bookFileDto.Id,
            Path = bookFileDto.Path,
            Size = bookFileDto.Size,
            FileExtension = bookFileDto.FileExtension
            // Boshqa maydonlarni kerak bo'lsa ularni ham ko'chirishingiz mumkin
        };
    }
}
