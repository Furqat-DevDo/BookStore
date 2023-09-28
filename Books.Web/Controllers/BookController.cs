using Books.Manage.Managers.Abstractions;
using Books.Web.Models;
using Books.Web.ViewManagers;
using Books.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class BookController : Controller
{
    private readonly IGenericViewManager<BookModel,CreateBookViewModel> _viewManager;

    public BookController(IGenericViewManager<BookModel, CreateBookViewModel> viewManager)
    {
        _viewManager = viewManager;
    }

    public IActionResult Home()
    {
        return View();
    }

    [HttpGet]
    public IActionResult About(BookModel model)
    {
        return View(model);
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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBookViewModel model)
    {
        if(! ModelState.IsValid)
            return View(model);

        var newBook = await _viewManager.CreateAsync(model);
        return RedirectToAction("About", newBook);
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

        return RedirectToAction("Books",routeValues:result);
    }

}