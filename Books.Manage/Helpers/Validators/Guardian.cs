using System.Globalization;

namespace Books.Manage.Helpers.Validators;

public class Guardian : IGuardian
{
    public Task GuardAgainstNull<T>(T input)
    {
        if(input is null)
            throw new ArgumentNullException(nameof(input));

        return Task.CompletedTask;
    }

    public Task GuardAgainstZeroAndMinus<T> (T input) where T: IConvertible,IEquatable<T>
    {
        if(Convert.ToDouble(input) == 0 || Convert.ToDouble(input) < 0)
            throw new ArgumentException(nameof(input));

        return Task.CompletedTask;
    }

    public Task GuardAgainstNullOrEmptyString<T>(T input) where T : IConvertible
    {
        if(string.IsNullOrWhiteSpace(Convert.ToString(input, CultureInfo.InvariantCulture)))
            throw new ArgumentNullException(nameof(input));

        return Task.CompletedTask;
    }
}