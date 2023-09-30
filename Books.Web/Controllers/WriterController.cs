using Books.Manage.Managers;
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

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> CreateWriter()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateWriter(CreateWriterModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var newWriter = await _writerManager.CreateWriterAsync(model);
        return RedirectToAction("About", newWriter);
    }



}