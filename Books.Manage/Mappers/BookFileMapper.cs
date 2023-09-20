using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;


namespace Books.Manage.Mappers;

public class BookFileMapper:IBookFileMapper
{
    public BookFileDto MapToDto(CreateBookFile bookFile)
    {
        var filemodel = new BookFileDto
        {
            FileExtension = bookFile.FileExtension,
            Path = bookFile.Path,
            Size = bookFile.Size,
            BookId = bookFile.BookId
        };


        return filemodel;
    }


    public BookFileDto MapToEntity(BookFile entity)
    {
        var file = new BookFileDto
        { 
            Id=entity.Id,
            Path=entity.Path,
            Size=entity.Size,
            FileExtension = entity.FileExtension,
            BookId = entity.BookId
        };

        return file;
    }

    public BookFile Update(BookFile bookFile, CreateBookFile bookFileModel)
    {
        bookFile.FileExtension = bookFileModel.FileExtension;
        bookFile.Path = bookFileModel.Path;
        bookFile.Size = bookFileModel.Size;
        bookFile.BookId = bookFileModel.BookId;
        bookFile.Id = bookFileModel.Id;

        return bookFile;
    }
}
