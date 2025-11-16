using static AsmCtl.Core.Functional.Results;

namespace AsmCtl.Core.Functional;

public static class Branching
{
    extension<T>(T? value)
    {
        public TResult Match<TResult>(Func<TResult> whenNull, Func<T, TResult> whenSome)
        {
            return value is null ? whenNull() : whenSome(value);
        }

        public Result<T> AsResult(
            string? errorMessage = null
        )
        {
            errorMessage ??= "Value is null";
            
            return value is null ? Failure(errorMessage) : Ok(value);
        }
    }
}