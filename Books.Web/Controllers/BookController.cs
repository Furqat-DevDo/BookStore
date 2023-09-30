using Books.Manage.Managers.Abstractions;
using Books.Web.Models;
using Books.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class BookController : Controller
{
  

    public BookController()
    {
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
    public IActionResult Books(BookModel books)
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
    public async Task<IActionResult> CreateAsync(CreateBookModel model)
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


        return RedirectToAction("Books");
    }

}