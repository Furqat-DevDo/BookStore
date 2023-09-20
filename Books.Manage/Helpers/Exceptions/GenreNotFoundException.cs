

namespace Books.Manage.Helpers.Exceptions;

public class GenreNotFoundException : Exception
{
    public GenreNotFoundException(string message) : base(message) { }
}
