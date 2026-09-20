using System.Text;

public sealed class NotebookRepository(IConfiguration configuration)
{
    private readonly string root = configuration["CSCS_BOOK_ROOT"] ?? "/workspace";
    private readonly string backupRoot = configuration["CSCS_BACKUP_ROOT"] ?? "/data/notebook-backups";

    public async Task<NotebookSaveResult> SaveAsync(string relativePath, string content, string actor, CancellationToken cancellationToken)
    {
        var pathResult = ResolvePath(relativePath);
        if (!pathResult.IsValid) return NotebookSaveResult.Failure(pathResult.Error!);

        var validation = NotebookValidation.Validate(content);
        if (!validation.IsValid) return NotebookSaveResult.Failure(validation.Message);

        var path = pathResult.Path!;
        if (!File.Exists(path)) return NotebookSaveResult.Failure("The notebook file does not exist.");

        try
        {
            Directory.CreateDirectory(backupRoot);
            var backupPath = Path.Combine(backupRoot, $"{DateTime.UtcNow:yyyyMMdd-HHmmssfff}-{Path.GetFileName(path)}.bak");
            File.Copy(path, backupPath);

            var temporaryPath = $"{path}.{Guid.NewGuid():N}.tmp";
            await File.WriteAllTextAsync(temporaryPath, content, new UTF8Encoding(false), cancellationToken);
            TrySetNotebookPermissions(temporaryPath);
            File.Move(temporaryPath, path, overwrite: true);
            TrySetNotebookPermissions(path);

            return NotebookSaveResult.Success(relativePath, backupPath, actor, validation.CellCount);
        }
        catch (UnauthorizedAccessException exception)
        {
            return NotebookSaveResult.Failure($"The notebook file could not be saved: {exception.Message}");
        }
        catch (IOException exception)
        {
            return NotebookSaveResult.Failure($"The notebook file could not be saved: {exception.Message}");
        }
    }

    private static void TrySetNotebookPermissions(string path)
    {
        try
        {
            if (OperatingSystem.IsWindows()) return;
            File.SetUnixFileMode(
                path,
                UnixFileMode.UserRead |
                UnixFileMode.UserWrite |
                UnixFileMode.GroupRead |
                UnixFileMode.GroupWrite |
                UnixFileMode.OtherRead);
        }
        catch (Exception exception) when (exception is PlatformNotSupportedException or UnauthorizedAccessException or IOException)
        {
            // Permissions are best-effort; the save itself is the critical operation.
        }
    }

    public async Task<NotebookReadResult> ReadAsync(string relativePath, CancellationToken cancellationToken)
    {
        var pathResult = ResolvePath(relativePath);
        if (!pathResult.IsValid) return NotebookReadResult.Failure(pathResult.Error!);
        var path = pathResult.Path!;
        if (!File.Exists(path)) return NotebookReadResult.Failure("The notebook file does not exist.");
        return NotebookReadResult.Success(await File.ReadAllTextAsync(path, cancellationToken));
    }

    private (bool IsValid, string? Path, string? Error) ResolvePath(string relativePath)
    {
        if (string.IsNullOrWhiteSpace(relativePath) || Path.IsPathRooted(relativePath))
            return (false, null, "A relative notebook path is required.");

        var normalized = relativePath.Replace('\\', '/');
        if (!normalized.StartsWith("chapters/", StringComparison.Ordinal) ||
            !normalized.EndsWith(".ipynb", StringComparison.OrdinalIgnoreCase) ||
            normalized.Contains("../", StringComparison.Ordinal) || normalized.Contains("/..", StringComparison.Ordinal))
            return (false, null, "Only notebook files under chapters/ may be saved.");

        var rootPath = Path.GetFullPath(root);
        var fullPath = Path.GetFullPath(Path.Combine(rootPath, normalized));
        if (!fullPath.StartsWith(rootPath + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            return (false, null, "The notebook path is outside the book root.");

        return (true, fullPath, null);
    }
}

public sealed record NotebookSaveRequest(string? Path, string? Content);
public sealed record NotebookReadResult(bool Found, string Message, string? Content)
{
    public static NotebookReadResult Success(string content) => new(true, "Notebook loaded.", content);
    public static NotebookReadResult Failure(string message) => new(false, message, null);
}

public sealed record NotebookSaveResult(bool Saved, string Message, string? Path, string? BackupPath, string? Actor, int CellCount)
{
    public static NotebookSaveResult Success(string path, string backupPath, string actor, int cellCount) =>
        new(true, "Notebook saved.", path, backupPath, actor, cellCount);

    public static NotebookSaveResult Failure(string message) =>
        new(false, message, null, null, null, 0);
}
