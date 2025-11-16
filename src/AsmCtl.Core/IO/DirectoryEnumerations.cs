using System.Collections.Immutable;
using AsmCtl.Core.Functional;
using static AsmCtl.Core.Functional.Results;

namespace AsmCtl.Core.IO;

public static class DirectoryEnumerations
{
    extension(DirectoryPath directoryPath)
    {
        public Result<ImmutableList<DirectoryPath>> AllDirectories()
        {
            try
            {
                return Directory.EnumerateDirectories(
                        directoryPath.Value
                    )
                    .Select(DirectoryPath.FromKnownPath)
                    .ToImmutableList();
            }
            catch (Exception e)
            {
                return Failure($"Failed to enumerate directory paths: {e.Message}");
            }
        }
    }
}