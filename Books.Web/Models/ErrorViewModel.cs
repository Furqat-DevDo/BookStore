namespace Books.Web.Models;

public class ErrorViewModel
{
    /// <summary>
    /// Return Url path where come from.
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// Exceptions Messages.
    /// </summary>
    public List<string>? Messages { get; set; }
}