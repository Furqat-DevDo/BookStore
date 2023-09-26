using System.ComponentModel.DataAnnotations;

namespace Books.Web.Models;

public class SearchModel
{
    [MinLength(4,ErrorMessage = "The length must to be more than 4 characters.")]
    [Display(Name = "Filter")]
    public required string Filter { get; set; }
}