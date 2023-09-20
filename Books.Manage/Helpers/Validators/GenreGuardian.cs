

using System.ComponentModel;
using System.Globalization;

namespace Books.Manage.Helpers.Validators;

public class GenreGuardian : IGenreGuardian
{
    public Task GernreGuardMinus<T>(T input) where T : IComparable, IEquatable<T>
    {
       if(Convert.ToDouble(input) < 0) throw new ArgumentOutOfRangeException(nameof(input));
       return Task.CompletedTask;
    }

    public Task GernreGuardNull<T>(T input) 
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        return Task.CompletedTask;
    }

    public Task GernreGuardNullOrEmptyString<T>(T input) where T : IComparable
    {
        if(string.IsNullOrWhiteSpace(Convert.ToString(input,CultureInfo.InvariantCulture))) 
            throw new ArgumentNullException(nameof(input));
        return Task.CompletedTask;
    }

    public Task GernreGuardZero<T>(T input) where T : IComparable,IEquatable<T>
    {
       if(Convert.ToDouble(input) == 0) throw new NotImplementedException(nameof(input));
       return Task.CompletedTask;
    }
}
