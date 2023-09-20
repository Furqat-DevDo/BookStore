namespace Books.Manage.Helpers.Validators;

public interface IGenreGuardian
{
    Task GernreGuardNull<T>(T input);
    Task GernreGuardZero<T>(T input) where T : IComparable, IEquatable<T>;
    Task GernreGuardMinus<T>(T input) where T : IComparable, IEquatable<T>;
    Task GernreGuardNullOrEmptyString<T>(T input) where T : IComparable;
}
