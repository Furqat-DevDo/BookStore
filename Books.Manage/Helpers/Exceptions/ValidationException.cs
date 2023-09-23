using System.Runtime.Serialization;

namespace Books.Manage.Helpers.Exceptions;

[Serializable]
public class ValidationException : ArgumentNullException
{
    public ValidationException()
    {
    }

    public ValidationException(string? message) : base(message)
    {
    }

    public ValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ValidationException(string message, string paramsName) : base(message, paramsName)
    {
        
    }
}