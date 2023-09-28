using Books.Manage.Managers.Abstractions;
using Books.Web.ViewModels;

namespace Books.Web.ViewManagers;

public class BookViewManager : IGenericViewManager<BookModel,CreateBookViewModel>
{
    private readonly IBookManager _bookManager;
    private readonly IGenreManager _genreManager;
    private readonly IWriterManager _writerManager;
    private readonly IBookSeriesManager _bookSeriesManager;
    private readonly IBookFileManager _bookFileManager;

    public BookViewManager(
        IBookManager bookManager, 
        IGenreManager genreManager, 
        IWriterManager writerManager, 
        IBookSeriesManager bookSeriesManager, 
        IBookFileManager bookFileManager)
    {
        _bookManager = bookManager;
        _genreManager = genreManager;
        _writerManager = writerManager;
        _bookSeriesManager = bookSeriesManager;
        _bookFileManager = bookFileManager;
    }
    public async Task<BookModel> CreateAsync(CreateBookViewModel model)
    {
        var writer = await _writerManager.GetOrCreateWriterAsync(model.WriterName);

        var createFile = new CreateBookFileModel(model.BookFile);
        var fileModel = await _bookFileManager.CreateBookFileAsync(createFile);

        var createCover = new CreateBookFileModel(model.CoverImage);
        var coverModel = await _bookFileManager.CreateBookFileAsync(createCover);

        var book = new CreateBookModel(
            model.Name,
            writer.Id,
            model.GenreList,
            fileModel.Path,
            coverModel.Path,
            model.Description);

        var newBook = await _bookManager.CreateBookAsync(book);
        return newBook;
    }

    public Task<CreateBookViewModel> ReturnAsync(BookModel model)
    {
        throw new NotImplementedException();
    }
}