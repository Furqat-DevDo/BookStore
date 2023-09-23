
using Books.Manage.Helpers.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Helpers.FileHelper;

public class FileHelper
{
    private readonly ILogger<FileHelper> _logger;

    public FileHelper(ILogger<FileHelper> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Will save file specified destination.
    /// </summary>
    /// <param name="formFile"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    public  async Task<(string, string, Guid)> SaveFileAsync(IFormFile formFile,string destination)
    {
        
        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }

        var fileId = Guid.NewGuid();
        var fileExtension = Path.GetExtension(formFile.FileName);

        var fileName = fileId.ToString("N") + fileExtension;

        var destinationFilePath = Path.Combine(destination, fileName);

        await using var destinationStream = File.Create(destinationFilePath);
        await formFile.CopyToAsync(destinationStream);

        return (destinationFilePath, fileExtension, fileId);
    }


    /// <summary>
    /// Read File from source or throw an exception.
    /// </summary>
    /// <param name="filePath"></param>
    /// <exception cref="ValidationException"></exception>
    public async Task<byte[]> ReadFileAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            _logger.LogError("File path is invalid or does not exist.");
            throw new ValidationException("Invalid file path.",nameof(filePath));
        }

        byte[] byteArray;

        try
        {
            byteArray = await File.ReadAllBytesAsync(filePath);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while reading the file.");
            throw new ValidationException("Invalid file path.", nameof(filePath));
        }

        return byteArray;
    }
}
