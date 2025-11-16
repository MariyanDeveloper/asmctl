using AsmCtl.Core.Functional;
using static AsmCtl.Core.Functional.Results;

namespace AsmCtl.Core.IO;

public static class FilePathComposition
{
    extension(FilePath filePath)
    {
        public static FilePath FromKnown(string path) => new(path);

        public static Result<FilePath> FromExistingPath(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return Failure($"Cannot find file {fileName}");
            }

            return new FilePath(fileName);
        }

        public static Result<FilePath> FromDirectoryAndFilePath(
            DirectoryPath directoryPath,
            FilePath file
        )
        {
            try
            {
                var fullPath = Path.Combine(
                    paths: [directoryPath.Value, Path.GetFileName(file.Value)]
                );

                if (!fullPath.IsValidSyntax())
                {
                    return Failure($"Cannot get full path {fullPath}");
                }

                return new FilePath(fullPath);
            }
            catch (Exception e)
            {
                return Failure($"Cannot get full path. {e.Message}");
            }
        }
    }
}