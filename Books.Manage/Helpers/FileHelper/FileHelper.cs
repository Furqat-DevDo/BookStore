
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Books.Manage.Helpers.FileHelper;

public static class FileHelper
{
    private static string destination = "./Files";
    private static ILoggerFactory _loggerFactory = new LoggerFactory();

    public static async Task<(string, string, Guid)> SaveFileAsync(IFormFile formFile)
    {
        if (formFile is null)
        {
            var logger = _loggerFactory.CreateLogger("File");
            logger.LogError("Form file is null.");
            throw new ArgumentNullException(nameof(formFile)); ;

        }

        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }

        var fileId = Guid.NewGuid();
        string fileExtension = Path.GetExtension(formFile.FileName);
        string fileName = fileId.ToString("N") + fileExtension;
        string destinationFilePath = Path.Combine(destination, fileName);

        using FileStream destinationStream = File.Create(destinationFilePath);
        await formFile.CopyToAsync(destinationStream);

        return (destinationFilePath, fileExtension, fileId);
    }

    public static async Task<byte[]> ReadFileAsync(string filePath)
    {
        if (filePath == null || !File.Exists(filePath))
        {
            var logger = _loggerFactory.CreateLogger("FileOperations");
            logger.LogError("File path is invalid or does not exist.");
            throw new ArgumentException("Invalid file path.", nameof(filePath));
        }
        byte[] byteArray = new byte[0];

        try
        {
            byteArray = await File.ReadAllBytesAsync(filePath);
        }
        catch (Exception ex)
        {
            var logger = _loggerFactory.CreateLogger("FileOperations");
            logger.LogError(ex, "An error occurred while reading the file.");
            throw new ArgumentException("Invalid file path.", nameof(filePath));
        }

        return byteArray;
    }
}
