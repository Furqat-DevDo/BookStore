using Books.Manage.Managers.Abstractions;
using Books.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class BookController : Controller
{
    private readonly IBookManager _bookManager;
    private readonly IBookFileManager _bookFileManager;

    public BookController(IBookManager bookManager, IBookFileManager bookFileManager)
    {
        _bookManager = bookManager;
        _bookFileManager = bookFileManager;
    }

    [HttpGet]
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
    public IActionResult Books(ResultBooksModel books)
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
    public async Task<IActionResult> Create(BookCreateViewModel model)
    {
        if(!ModelState.IsValid)
            return View(model);

        
        return RedirectToAction("About");
    }

    [HttpGet]
    public IActionResult Search()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Search(SearchModel model)
    {
        return View();
        /*if(!ModelState.IsValid)
        {
            return View(model);
        }

        var result = "";

        return RedirectToAction("Books");*/
    }

}