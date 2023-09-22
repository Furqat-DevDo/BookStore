using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class WriterController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}