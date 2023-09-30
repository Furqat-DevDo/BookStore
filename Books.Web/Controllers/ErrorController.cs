using Books.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class ErrorController : Controller
{
    [HttpGet("Error")]
    public IActionResult Errors(string path = null, List<string> errorMessages = null)
    {
        var errors = new ErrorViewModel
        {
            Path = path,
            Messages = errorMessages ?? new List<string>()
        };

        return View(errors);
    }
}