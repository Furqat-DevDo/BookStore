﻿using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controllers;

public class FileController : Controller
{

    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost]
    public async Task<JsonResult> Upload(IFormFile file)
    {
        string filePath = string.Empty;

        if (ModelState.IsValid)
        {
            try
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid() + "_" + file.FileName;
                filePath = Path.Combine(uploadsFolder, uniqueFileName);

                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                ViewBag.Message = "File uploaded successfully!";
            }
            catch (Exception ex)
            {
                return Json("Error: " + ex.Message);
            }
        }

        return Json(filePath);
    }

    [HttpGet]
    public IActionResult Download(string fileSrc)
    {
        if (string.IsNullOrEmpty(fileSrc))
        {
            return NotFound();
        }

        if (!System.IO.File.Exists(fileSrc))
        {
            return NotFound();
        }

        // Determine the content type based on the file extension
        string contentType = GetContentType(fileSrc);

        // Return the file as a FileStreamResult for download
        var fileStream = new FileStream(fileSrc, FileMode.Open, FileAccess.Read);
        var fileName = Path.GetFileName(fileSrc);
        return File(fileStream, contentType, fileName);
    }

    private string GetContentType(string fileName)
    {
        // Determine the content type based on the file extension
        string fileExtension = Path.GetExtension(fileName).ToLower();

        switch (fileExtension)
        {
            case ".pdf":
                return "application/pdf";
            case ".txt":
                return "text/plain";
            case ".jpg":
            case ".jpeg":
                return "image/jpeg";
            // Add more content type mappings here...
            default:
                return "application/octet-stream";
        }
    }

}