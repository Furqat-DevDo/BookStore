using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Helpers.Exceptions;

public class BookGenreNotFoundException : Exception
{
    public BookGenreNotFoundException(string message) : base(message) { }
}
