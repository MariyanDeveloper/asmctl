using AsmCtl.Core.Shared;

namespace AsmCtl.Core.Functional;

public readonly struct Result<T>
{
    public T? Value { get; }

    public Error? Error { get; }

    public bool IsSuccess => Error is null;

    public bool IsFailure => Error is not null;

    public Result(T value)
    {
        Value = value;
        Error = null;
    }

    public Result(Error error)
    {
        Value = default;
        Error = error;
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(value);
    }

    public static implicit operator Result<T>(Error error)
    {
        return new Result<T>(error);
    }

    public TOutput Match<TOutput>(Func<T, TOutput> success, Func<Error, TOutput> failure)
    {
        return IsSuccess ? success(Value!) : failure(Error!);
    }

    public void Match(Action<T> success, Action<Error> failure)
    {
        if (IsSuccess)
        {
            success(Value.NotNull());
            return;
        }

        failure(Error.NotNull());
    }
}
