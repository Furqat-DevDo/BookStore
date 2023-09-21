namespace Books.Manage.Helpers.Exceptions;

public class BookSeriesNotFoundException : Exception
{
    public BookSeriesNotFoundException(string message) : base(message) { }
}
