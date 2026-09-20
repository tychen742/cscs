using System.Diagnostics;

public sealed class GitRepository(IConfiguration configuration)
{
    private readonly string root = configuration["CSCS_BOOK_ROOT"] ?? "/workspace";

    public async Task<GitSyncResult> SyncAsync(string actor, string? message, CancellationToken cancellationToken)
    {
        var rootPath = Path.GetFullPath(root);
        if (!Directory.Exists(Path.Combine(rootPath, ".git")))
            return GitSyncResult.Failure("The book root is not a Git checkout.");

        var statusBefore = await GitAsync(["status", "--porcelain"], cancellationToken);
        if (!statusBefore.Succeeded) return GitSyncResult.Failure(statusBefore.Error);

        var committed = false;
        var commitMessage = string.IsNullOrWhiteSpace(message)
            ? $"Browser authoring updates by {actor}"
            : message.Trim();

        if (!string.IsNullOrWhiteSpace(statusBefore.Output))
        {
            var add = await GitAsync(["add", "-A", "--", "chapters", "_static", "authoring", "execution", "_config.yml", "_toc.yml", "README.md", "AGENTS.md"], cancellationToken);
            if (!add.Succeeded) return GitSyncResult.Failure(add.Error);

            var diff = await GitAsync(["diff", "--cached", "--quiet"], cancellationToken, allowExitCodes: [0, 1]);
            if (diff.ExitCode == 1)
            {
                var commit = await GitAsync(["commit", "-m", commitMessage], cancellationToken);
                if (!commit.Succeeded) return GitSyncResult.Failure(commit.Error);
                committed = true;
            }
        }

        var pull = await GitAsync(["pull", "--rebase", "origin", "main"], cancellationToken);
        if (!pull.Succeeded) return GitSyncResult.Failure(pull.Error);

        var push = await GitAsync(["push", "origin", "main"], cancellationToken);
        if (!push.Succeeded) return GitSyncResult.Failure(push.Error);

        var statusAfter = await GitAsync(["status", "--porcelain"], cancellationToken);
        if (!statusAfter.Succeeded) return GitSyncResult.Failure(statusAfter.Error);

        var head = await GitAsync(["rev-parse", "--short", "HEAD"], cancellationToken);
        return GitSyncResult.Success(committed, head.Output.Trim(), statusAfter.Output.Trim());
    }

    private async Task<GitCommandResult> GitAsync(string[] arguments, CancellationToken cancellationToken, int[]? allowExitCodes = null)
    {
        allowExitCodes ??= [0];
        var startInfo = new ProcessStartInfo
        {
            FileName = "git",
            WorkingDirectory = root,
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false
        };
        startInfo.ArgumentList.Add("-c");
        startInfo.ArgumentList.Add($"safe.directory={Path.GetFullPath(root)}");
        foreach (var argument in arguments)
        {
            startInfo.ArgumentList.Add(argument);
        }

        using var process = Process.Start(startInfo);
        if (process is null) return new GitCommandResult(false, -1, string.Empty, "Git could not be started.");

        var outputTask = process.StandardOutput.ReadToEndAsync(cancellationToken);
        var errorTask = process.StandardError.ReadToEndAsync(cancellationToken);
        await process.WaitForExitAsync(cancellationToken);

        var output = await outputTask;
        var error = await errorTask;
        var succeeded = allowExitCodes.Contains(process.ExitCode);
        return new GitCommandResult(succeeded, process.ExitCode, output, string.IsNullOrWhiteSpace(error) ? output : error);
    }

    private sealed record GitCommandResult(bool Succeeded, int ExitCode, string Output, string Error);
}

public sealed record GitSyncResult(bool Synced, string Message, bool Committed, string? Head, string? Status)
{
    public static GitSyncResult Success(bool committed, string head, string status) =>
        new(true, "Git sync complete.", committed, head, status);

    public static GitSyncResult Failure(string message) =>
        new(false, message, false, null, null);
}

public sealed record GitSyncRequest(string? Message);
