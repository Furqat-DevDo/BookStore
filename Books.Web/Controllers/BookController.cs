using Books.Manage.Managers.Abstractions;
using Books.Web.Models;
using Books.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class BookController : Controller
{
    private readonly IBookManager _bookManager;
    private readonly IGenreManager _genreManager;
    private readonly IWriterManager _writerManager;
    private readonly IBookSeriesManager _bookSeriesManager;

    public BookController(
        IBookManager bookManager, 
        IGenreManager genreManager, 
        IWriterManager writerManager, 
        IBookSeriesManager bookSeriesManager)
    {
        _bookManager = bookManager;
        _genreManager = genreManager;
        _writerManager = writerManager;
        _bookSeriesManager = bookSeriesManager;
    }

    public IActionResult Home()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Books(BookViewModel books)
    {
        return View(books);
    }

    [HttpGet]
    public IActionResult Books()
    {
        return View();
    }

    public IActionResult Search()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Search(SearchModel model)
    {

        if(!ModelState.IsValid)
        {
            return View(model);
        }

        var result = new BookViewModel();

        var book = await _bookManager.GetBookByNameAsync(model.Filter);
        


        return RedirectToAction("Books",routeValues:result);
    }

}