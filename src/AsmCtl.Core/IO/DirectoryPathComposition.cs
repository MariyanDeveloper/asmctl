using AsmCtl.Core.Functional;
using static AsmCtl.Core.Functional.Results;

namespace AsmCtl.Core.IO;

public static class DirectoryPathComposition
{
    extension(DirectoryPath path)
    {
        public static DirectoryPath FromKnownPath(string knownPath) => new(knownPath);

        public static Result<DirectoryPath> FromExistingPath(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                return Failure($"Cannot find directory {directoryPath}");
            }

            return new DirectoryPath(directoryPath);
        }

        public static Result<DirectoryPath> Current()
        {
            try
            {
                return FromExistingPath(Directory.GetCurrentDirectory());
            }
            catch (Exception e)
            {
                return Failure($"Cannot get current directory. {e.Message}");
            }
        }

        public static Result<DirectoryPath> FromCombined(
            params string[] paths
        )
        {
            var anyPathInvalid = paths.Any(path => !path.IsValidSyntax());

            if (anyPathInvalid)
            {
                return Failure($"Any provided path is invalid. {string.Join(", ", paths)}");
            }

            return new DirectoryPath(Path.Combine(paths));
        }
    }
}