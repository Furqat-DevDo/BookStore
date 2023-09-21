using Books.Manage.Helpers.Exceptions;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Managers;

public class BookManager  : IBookManager
{
    private readonly IGuardian _guardian;
    private readonly IBookMapper _mapper;
    private readonly IBookRepository _repository;
    private readonly IBookFileRepository _bookFileRepository;

    public BookManager(
        IGuardian guardian, 
        IBookMapper mapper, 
        IBookRepository repository,
        IBookFileRepository bookFileRepository)
    {
        _guardian = guardian;
        _mapper = mapper;
        _repository = repository;
        _bookFileRepository = bookFileRepository;
    }

    public async  Task<BookModel> CreateBookAsync(CreateBookModel model)
    {
        await _guardian.GuardAgainstNull(model);
        
        var entity = await  _repository.CreateBook(
            _mapper.ToEntity(model));

        return _mapper.ToModel(entity);
    }

    public async Task<BookModel> UpdateBookAsync(int id, CreateBookModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var book = await  _repository.GetById(id);
        if (book is null) throw new BookNotFoundException(nameof(book));

        var entity = await _repository.UpdateBook(
            _mapper.Update(book,model));

        return _mapper.ToModel(entity);
    }

    public async  Task<bool> DeleteBookAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);
        
        await _bookFileRepository.DeleteBookFileAsync(id);
        return await _repository.DeleteById(id);
    }

    public async  Task<BookModel> GetBookByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var book = await  _repository.GetById(id);

        if(book is null) throw new BookNotFoundException(nameof(book));

        return _mapper.ToModel(book);
    }

    public async Task<BookModel> GetBookByNameAsync(string name)
    {
       await _guardian.GuardAgainstNullOrEmptyString(name);

       var book = await _repository.GetBookByFilter(b=>b.Name == name);
       if (book is null) throw new BookNotFoundException(nameof(book));

       return _mapper.ToModel(book);
    }

    public async Task<BookModel> GetBookByWriterId(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var book = await _repository.GetBookByFilter(b => b.WriterId == id);

        if (book is null) throw new BookNotFoundException(nameof(book));

        return _mapper.ToModel(book);
    }


    public async Task<List<BookModel>> GetBooksAsync()
    {
        var books = await _repository.GetAll();
        
        return !books.Any() ? new List<BookModel>()
            : books.Select(_mapper.ToModel).ToList();
    }  
}