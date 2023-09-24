using Books.Core.Entities;
using Books.Manage.Helpers.FileManager;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;

namespace Books.Manage.Mappers;

public class BookFileMapper : IGenericMapper<FileCreateModel,BookFile,BookFileModel>
{
    private readonly IFileManager _fileManager;

    public BookFileMapper(IFileManager fileManager)
    {
        _fileManager = fileManager;
    }

    [Obsolete("Method deso not implemented.",true)]
    public BookFile ToEntity(FileCreateModel model)
        => throw new NotImplementedException();
    

    public BookFileModel ToModel(BookFile file)
    {
        var filemodel = new BookFileModel
        {
            Id =  file.Id,
            Path = file.Path,
            FileExtension = file.FileExtension,
            Size = file.Size,
            BookId = file.BookId,
            CreatedDate = file.CreatedDate,
        };

        return filemodel;
    }

    [Obsolete("Method deso not implemented.",true)]
    public BookFile Update(BookFile entity, FileCreateModel model)
       => throw new NotImplementedException();
    
}
