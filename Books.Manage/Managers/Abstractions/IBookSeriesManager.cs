using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Managers.Abstractions;

public class BookSeriesModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int BookId { get; set; }
    public int WriterId { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
public interface IBookSeriesManager
{
    
}
