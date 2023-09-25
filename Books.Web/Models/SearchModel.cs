using System.Diagnostics.CodeAnalysis;

namespace Books.Web.Models;

public class SearchModel
{
    [NotNull]
    public required string Filter { get; set; }
}