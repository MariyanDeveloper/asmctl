using AsmCtl.Core.Shared;

namespace AsmCtl.Core.Functional;

public static class ResultExtensions
{
    public static Result<TOutput> Map<T, TOutput>(this Result<T> self, Func<T, TOutput> func)
    {
        return self.Match<Result<TOutput>>(success: value => func(value), failure: error => error);
    }

    public static Result<TOutput> Then<T, TOutput>(
        this Result<T> self,
        Func<T, Result<TOutput>> func
    )
    {
        return self.Match(success: func, failure: error => error);
    }

    public static void Do<T>(this Result<T> self, Action<T> action)
    {
        if (self.IsSuccess)
        {
            action(self.Value.NotNull());
        }
    }
}
