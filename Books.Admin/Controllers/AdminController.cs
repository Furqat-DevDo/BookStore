using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        return View("dashboard");
    }
}