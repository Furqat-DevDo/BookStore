﻿namespace Books.Manage.Helpers.Validators;

public interface IGuardian
{
    Task GuardAgainstNull<T>(T input);
    Task GuardAgainstZeroAndMinus<T>(T input) where T: IConvertible,IEquatable<T>;
    Task GuardAgainstNullOrEmptyString<T>(T input) where T : IConvertible;
}