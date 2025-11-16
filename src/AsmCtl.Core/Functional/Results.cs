namespace AsmCtl.Core.Functional;

public static class Results
{
    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value);
    }

    public static Error Failure(string message)
    {
        return new Error(message);
    }
}
