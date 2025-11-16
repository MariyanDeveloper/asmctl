namespace AsmCtl.Core.Shared;

public static class Guards
{
    extension<T>(T? value)
    {
        public T NotNull()
        {
            return value ?? throw new NullReferenceException("Value must not be null");
        }
    }
}
