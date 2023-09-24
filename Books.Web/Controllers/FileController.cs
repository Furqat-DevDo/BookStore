using Books.Manage.Managers.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class FileController : Controller
{
    private readonly IBookFileManager _fileManager;

    public FileController(IBookFileManager fileManager)
    {
        _fileManager = fileManager;
    }
    [HttpGet]
    public IActionResult Files()
    {
        return View();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Files(CreateBookFileModel model)
    {
        if (!ModelState.IsValid)
        {

        }
        
        var result = await  _fileManager.CreateBookFileAsync(model);
        return View(result);
       
    }

}