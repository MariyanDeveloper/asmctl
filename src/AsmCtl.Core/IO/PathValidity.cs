namespace AsmCtl.Core.IO;

public static class PathValidity
{
    extension(string path)
    {
        public bool IsValidSyntax()
        {
            var invalidPathChars = Path.GetInvalidPathChars();

            var indexOfInvalidCharacter = path.IndexOfAny(anyOf: invalidPathChars);

            return indexOfInvalidCharacter < 0;
        }
    }
}