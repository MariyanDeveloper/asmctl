namespace AsmCtl.Core.IO;

public sealed record FilePath(string Value);

public sealed record DirectoryPath(string Value);

public sealed record CopiedFile(FilePath Source, FilePath Destination);
