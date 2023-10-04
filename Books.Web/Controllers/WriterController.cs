using Books.Manage.Managers.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class WriterController : Controller
{
    private readonly IWriterManager _writerManager;

    public WriterController(IWriterManager writerManager)
    {
        _writerManager = writerManager;
    }


    public IActionResult About()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateWriterModel model)
    {
        try
        {
            if (!ModelState.IsValid)
                return View(model);

            var newWriter = await _writerManager.CreateWriterAsync(model);
            return RedirectToAction("About", newWriter);
        }
        catch (Exception ex)
        {
            return View("Error", ex);
        }
    }

}