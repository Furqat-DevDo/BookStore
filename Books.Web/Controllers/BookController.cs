using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class BookController : Controller
{
    public IActionResult Home()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Books()
    {
        return View();
    }

    public IActionResult Search()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
}