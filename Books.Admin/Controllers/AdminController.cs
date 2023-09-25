using Microsoft.AspNetCore.Mvc;

namespace Books.Admin.Controllers;

public class AdminController : Controller
{
    [HttpGet]
    public IActionResult Dashboard()
    {
        return View();
    }
}