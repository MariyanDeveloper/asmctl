using AsmCtl.Core.Functional;
using static AsmCtl.Core.Functional.Results;

namespace AsmCtl.Core.IO;
public static class SafeIOWrappers
{
    extension(FileInfo fileInfo)
    {
        public Result<CopiedFile> Copy(string destinationFolder, bool overwrite)
        {
            try
            {
                var destinationFile = Path.Combine(destinationFolder, Path.GetFileName(fileInfo.Name));
                
                fileInfo.CopyTo(destFileName: destinationFile, overwrite: overwrite);
                
                return new CopiedFile(
                    Source: FilePath.FromKnown(fileInfo.FullName), Destination: FilePath.FromKnown(destinationFile));
            
            }
            catch (Exception e)
            {
                return Failure($"Failed to copy from: {fileInfo.FullName} to: {destinationFolder}. {e.Message}");
            }
        }
    }
}
