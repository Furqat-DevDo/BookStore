using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class FileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}