using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.HttpOverrides;

// CSCS C# runner: the only place student code runs. The container holds no secrets,
// mounts nothing, and sits on an internal network with no internet, database, or host
// access; cs-runner-gateway is its only way in. See execution/ARCHITECTURE.md and
// press/docs/PLATFORM_DECISIONS.md ("Code Execution Through Signed Run Passes").

const int maxCellCount = 20;
const string TypesOnlyEntryPoint = """


internal static class CscsTypesOnlyEntryPoint
{
    public static void Main() { }
}
""";

const string TypesOnlyMessage =
    "Compiled successfully. This cell only declares types, so there is no code to run." + "\n";
const int maxCodeLength = 100_000;
const int maxStdinLength = 10_000;
const int executionTimeoutMilliseconds = 15_000;
const int guestExecutionTimeoutMilliseconds = 8_000;
const int executionQueueTimeoutMilliseconds = 30_000;
const int guestExecutionQueueTimeoutMilliseconds = 20_000;

// Environment variables the student's build and program may see. Everything else,
// including anything added to this container later, is withheld from student code.
string[] studentEnvironmentAllowList =
[
    "PATH", "DOTNET_ROOT", "DOTNET_CLI_HOME", "DOTNET_SKIP_FIRST_TIME_EXPERIENCE",
    "DOTNET_CLI_TELEMETRY_OPTOUT", "DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_DISABLE", "DOTNET_NOLOGO",
    "DOTNET_RUNNING_IN_CONTAINER", "LANG", "LC_ALL"
];

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");
// Each run is a full `dotnet run` build, so cap simultaneous runs (default: one per
// CPU core) and make extra requests wait in line instead of competing for the host.
// Guests get a smaller share: fewer slots, lower priority, shorter timeouts, and a
// per-IP rate limit.
var maxConcurrentExecutions = PositiveIntSetting("CSCS_MAX_CONCURRENT_EXECUTIONS", 2);
var guestConcurrentExecutions = Math.Min(PositiveIntSetting("CSCS_GUEST_CONCURRENT_EXECUTIONS", 1), maxConcurrentExecutions);
var executionScheduler = new ExecutionScheduler(maxConcurrentExecutions, guestConcurrentExecutions);
var guestRunsPerMinute = PositiveIntSetting("CSCS_GUEST_RUNS_PER_MINUTE", 30);
var signedInRunsPerMinute = PositiveIntSetting("CSCS_SIGNED_IN_RUNS_PER_MINUTE", 30);
var runRateLimiter = PartitionedRateLimiter.Create<string, string>(key =>
    RateLimitPartition.GetSlidingWindowLimiter(key, partitionKey => new SlidingWindowRateLimiterOptions
    {
        PermitLimit = partitionKey.StartsWith("guest:", StringComparison.Ordinal) ? guestRunsPerMinute : signedInRunsPerMinute,
        Window = TimeSpan.FromMinutes(1),
        SegmentsPerWindow = 6,
        QueueLimit = 0
    }));
var allowedOrigins = (Environment.GetEnvironmentVariable("CSCS_ALLOWED_ORIGINS") ??
                      "https://cscs.thinkpress.org,https://thinkcscs.org,https://www.thinkcscs.org,http://localhost:3000,http://localhost:8000")
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
// No credentials: the runner never reads cookies or account state.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins(allowedOrigins).AllowAnyHeader().WithMethods("GET", "POST")));
// Requests arrive through Apache and cs-runner-gateway, which passes Apache's
// X-Forwarded-For through unchanged. ForwardLimit = 1 takes only the address Apache
// appended, so a client-supplied X-Forwarded-For cannot pick another IP's rate limit.
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor;
    options.ForwardLimit = 1;
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});
// Run passes signed by Press (press/docs/RUN_PASSES.md). Only public keys are configured:
// student code in this container can read them, and they cannot sign anything.
var runPassVerifier = PressPassVerifier.FromConfiguration(
    Environment.GetEnvironmentVariable("CSCS_RUN_PASS_PUBLIC_KEYS"),
    Environment.GetEnvironmentVariable("CSCS_RUN_PASS_AUDIENCE") ?? "cs-runner",
    Environment.GetEnvironmentVariable("CSCS_RUN_PASS_BOOK") ?? "cscs",
    "signed_in");
var app = builder.Build();
app.Logger.LogInformation("Run passes: {KeyCount} public key(s) configured", runPassVerifier.KeyCount);
app.UseForwardedHeaders();
app.UseCors();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapPost("/v1/tasks/{taskId}/execute", async (string taskId, ExecutionRequest request, HttpContext httpContext, CancellationToken cancellationToken) =>
{
    if (!Regex.IsMatch(taskId, "^[a-z0-9][a-z0-9/_-]{0,63}$"))
    {
        return Results.BadRequest(new { error = "The task ID contains unsupported characters." });
    }

    var cells = request.Cells is { Count: > 0 } ? request.Cells : [request.Code ?? string.Empty];

    if (cells.Count > maxCellCount)
    {
        return Results.BadRequest(new { error = $"A maximum of {maxCellCount} cells is allowed." });
    }

    if (cells.Any(cell => cell.Length > maxCodeLength))
    {
        return Results.BadRequest(new { error = $"Each cell must be at most {maxCodeLength} characters." });
    }

    if ((request.Stdin?.Length ?? 0) > maxStdinLength)
    {
        return Results.BadRequest(new { error = $"Input must be at most {maxStdinLength} characters." });
    }

    // A valid run pass from Press (Authorization: Bearer) gives the signed-in tier, limited
    // per user; anything else, including Press being down, runs at guest limits per IP.
    var subject = runPassVerifier.Verify(BearerToken(httpContext.Request), DateTimeOffset.UtcNow)?.Subject;
    var tier = subject is null ? ExecutionTier.Guest : ExecutionTier.SignedIn;
    var rateLimitKey = subject is null ? $"guest:{httpContext.Connection.RemoteIpAddress}" : $"user:{subject}";
    using var rateLimitLease = runRateLimiter.AttemptAcquire(rateLimitKey);
    if (!rateLimitLease.IsAcquired)
    {
        var limit = tier == ExecutionTier.Guest ? guestRunsPerMinute : signedInRunsPerMinute;
        return Results.Json(
            new { error = $"You have reached the limit of {limit} runs per minute. Please wait a moment and press Run again." },
            statusCode: StatusCodes.Status429TooManyRequests);
    }

    var source = BuildSource(cells.Select(NormalizeCell).ToList(), request.PrefixCellCount);
    var queueTimeout = tier == ExecutionTier.Guest ? guestExecutionQueueTimeoutMilliseconds : executionQueueTimeoutMilliseconds;
    if (!await executionScheduler.WaitAsync(tier, TimeSpan.FromMilliseconds(queueTimeout), cancellationToken))
    {
        var busyMessage = tier == ExecutionTier.Guest
            ? "The code runner is busy right now. Please wait a few seconds and press Run again. Signed-in readers get priority."
            : "The code runner is busy right now. Please wait a few seconds and press Run again.";
        return Results.Json(new { error = busyMessage }, statusCode: StatusCodes.Status503ServiceUnavailable);
    }

    try
    {
        var result = await ExecuteAsync(source, taskId, request.Stdin, tier, cancellationToken);
        if (result.ExitCode != 0 && !result.TimedOut && (result.Output + result.Error).Contains("error CS5001"))
        {
            // The cell only declares types (no statements, no Main). Rebuild with an empty
            // entry point so the declarations still compile and report what happened.
            var retry = await ExecuteAsync(source + TypesOnlyEntryPoint, taskId, request.Stdin, tier, cancellationToken);
            result = retry.ExitCode == 0
                ? retry with { Output = TypesOnlyMessage + retry.Output }
                : retry;
        }
        return Results.Ok(result);
    }
    finally
    {
        executionScheduler.Release(tier);
    }
});

app.Run();

async Task<ExecutionResult> ExecuteAsync(string source, string taskId, string? stdin, ExecutionTier tier, CancellationToken cancellationToken)
{
    var timeoutMilliseconds = tier == ExecutionTier.Guest ? guestExecutionTimeoutMilliseconds : executionTimeoutMilliseconds;
    var executionDirectory = Path.Combine(Path.GetTempPath(), $"cscs-{Guid.NewGuid():N}");

    try
    {
        // Copy inside the try so a partial copy (e.g. a full /tmp) is still cleaned up.
        DirectoryCopy("/app/runner-template", executionDirectory);
        await File.WriteAllTextAsync(Path.Combine(executionDirectory, "Program.cs"), source, cancellationToken);

        var startInfo = new ProcessStartInfo
        {
            // Guest builds run under `nice`, so the compiler and the program it starts
            // yield the CPU to signed-in runs when both are active.
            FileName = tier == ExecutionTier.Guest ? "nice" : "dotnet",
            WorkingDirectory = executionDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        if (tier == ExecutionTier.Guest)
        {
            startInfo.ArgumentList.Add("-n");
            startInfo.ArgumentList.Add("10");
            startInfo.ArgumentList.Add("dotnet");
        }
        startInfo.ArgumentList.Add("run");
        startInfo.ArgumentList.Add("--no-restore");
        startInfo.ArgumentList.Add("-p:UseAppHost=false");
        startInfo.ArgumentList.Add("--project");
        startInfo.ArgumentList.Add(Path.Combine(executionDirectory, "runner-template.csproj"));

        // Start the build and the student program from an allow-listed environment.
        startInfo.Environment.Clear();
        foreach (var name in studentEnvironmentAllowList)
        {
            if (Environment.GetEnvironmentVariable(name) is { } value) startInfo.Environment[name] = value;
        }
        startInfo.Environment["HOME"] = executionDirectory;
        startInfo.Environment["TMPDIR"] = executionDirectory;
        startInfo.Environment["NUGET_PACKAGES"] = "/app/.nuget/packages";

        using var process = Process.Start(startInfo);
        if (process is null)
        {
            return new ExecutionResult(taskId, string.Empty, "Unable to start the C# compiler.", -1, false);
        }

        await process.StandardInput.WriteAsync(stdin ?? string.Empty);
        process.StandardInput.Close();

        using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeout.CancelAfter(timeoutMilliseconds);

        try
        {
            await process.WaitForExitAsync(timeout.Token);
        }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            await process.WaitForExitAsync(CancellationToken.None);
            if (cancellationToken.IsCancellationRequested) throw;
            return new ExecutionResult(
                taskId,
                await process.StandardOutput.ReadToEndAsync(),
                $"Execution timed out after {timeoutMilliseconds / 1000} seconds.",
                -1,
                true);
        }

        var output = CleanOutput(await process.StandardOutput.ReadToEndAsync());
        var error = await process.StandardError.ReadToEndAsync();
        return new ExecutionResult(taskId, output, error, process.ExitCode, false);
    }
    finally
    {
        if (Directory.Exists(executionDirectory))
        {
            Directory.Delete(executionDirectory, recursive: true);
        }
    }
}

static string BuildSource(IReadOnlyList<string> cells, int prefixCellCount)
{
    var prefix = string.Join(Environment.NewLine + Environment.NewLine, cells.Take(prefixCellCount));
    var current = string.Join(Environment.NewLine + Environment.NewLine, cells.Skip(prefixCellCount));
    var usingLines = new List<string>();

    prefix = RemoveUsingDirectives(prefix, usingLines);
    current = RemoveUsingDirectives(current, usingLines);

    if (prefixCellCount == 0)
    {
        // Without using directives, add no leading line so compiler line numbers match the cell.
        return usingLines.Count == 0
            ? WrapLooseMembers(current)
            : string.Join(Environment.NewLine, usingLines) + Environment.NewLine + WrapLooseMembers(current);
    }

    return string.Join(
        Environment.NewLine,
        usingLines) + Environment.NewLine +
        "Console.SetOut(TextWriter.Null);" + Environment.NewLine +
        WrapLooseMembers(prefix) + Environment.NewLine +
        "Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });" +
        Environment.NewLine + WrapLooseMembers(current);
}

static string NormalizeCell(string source)
{
    return Regex.Replace(source, "^\\s*%{1,2}csharp\\s*\\r?\\n", string.Empty, RegexOptions.IgnoreCase);
}

static string RemoveUsingDirectives(string source, ICollection<string> usingLines)
{
    var body = new List<string>();
    foreach (var line in source.Split('\n'))
    {
        // Hoist only using directives (using X.Y; using static X; using Alias = X.Y;), never
        // using declarations such as "using StreamReader reader = new StreamReader(path);".
        if (Regex.IsMatch(line, "^\\s*(global\\s+)?using\\s+(static\\s+)?([A-Za-z_]\\w*\\s*=\\s*)?[A-Za-z_][\\w.<>, ]*;\\s*(//.*)?$"))
        {
            usingLines.Add(line.Trim());
        }
        else
        {
            body.Add(line);
        }
    }

    return string.Join('\n', body);
}

static string WrapLooseMembers(string source)
{
    if (!NeedsProgramWrapper(source)) return source;

    var hasUpperMain = Regex.IsMatch(source, "\\bstatic\\s+void\\s+Main\\s*\\(", RegexOptions.Multiline);
    var hasLowerMain = Regex.IsMatch(source, "\\bstatic\\s+void\\s+main\\s*\\(", RegexOptions.Multiline);
    var entryPoint = hasUpperMain
        ? string.Empty
        : hasLowerMain
            ? string.Empty
            : Environment.NewLine + "    public static void Main() { }" + Environment.NewLine;

    return "public class Program" + Environment.NewLine +
           "{" + Environment.NewLine +
           Indent(source) +
           entryPoint +
           "}";
}

static bool NeedsProgramWrapper(string source)
{
    if (string.IsNullOrWhiteSpace(source)) return false;
    if (Regex.IsMatch(source, "^\\s*(?:public\\s+|internal\\s+|private\\s+|protected\\s+)?(?:static\\s+)?(?:class|struct|record|enum|interface)\\s+\\w+", RegexOptions.Multiline))
        return false;
    if (Regex.IsMatch(source, "^\\s*namespace\\s+\\w+", RegexOptions.Multiline))
        return false;

    return Regex.IsMatch(source, "^\\s*(?:public|private|protected|internal)\\s+(?:static\\s+)?[\\w<>,?\\[\\]]+\\s+\\w+\\s*\\(", RegexOptions.Multiline);
}

static string Indent(string source)
{
    return string.Join(
        Environment.NewLine,
        source.Split('\n').Select(line => string.IsNullOrWhiteSpace(line) ? line.TrimEnd('\r') : "    " + line.TrimEnd('\r')));
}

static string CleanOutput(string output)
{
    return string.Join(
        Environment.NewLine,
        output.Split(Environment.NewLine)
            .Where(line => !line.StartsWith("An issue was encountered verifying workloads.", StringComparison.Ordinal) &&
                           !line.StartsWith("For more information, run \"dotnet workload update\".", StringComparison.Ordinal)));
}

static string? BearerToken(HttpRequest request)
{
    var header = request.Headers.Authorization.ToString();
    return header.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) ? header["Bearer ".Length..].Trim() : null;
}

static int PositiveIntSetting(string name, int fallback) =>
    int.TryParse(Environment.GetEnvironmentVariable(name), out var value) && value > 0 ? value : fallback;

static void DirectoryCopy(string sourceDirectory, string destinationDirectory)
{
    Directory.CreateDirectory(destinationDirectory);
    foreach (var file in Directory.EnumerateFiles(sourceDirectory))
    {
        File.Copy(file, Path.Combine(destinationDirectory, Path.GetFileName(file)));
    }

    foreach (var directory in Directory.EnumerateDirectories(sourceDirectory))
    {
        DirectoryCopy(directory, Path.Combine(destinationDirectory, Path.GetFileName(directory)));
    }
}

public sealed record ExecutionRequest(string? Code, List<string>? Cells, string? Stdin, int PrefixCellCount = 0);

public sealed record ExecutionResult(string TaskId, string Output, string Error, int ExitCode, bool TimedOut);

public enum ExecutionTier
{
    Guest,
    SignedIn
}

/// <summary>
/// Hands out a fixed number of run slots. Signed-in readers are served first, and
/// guests may hold at most <c>guestSlots</c> at once, so some capacity is always
/// left for signed-in readers. Waiters within a tier are served in arrival order.
/// </summary>
public sealed class ExecutionScheduler(int totalSlots, int guestSlots)
{
    private readonly object sync = new();
    private readonly LinkedList<TaskCompletionSource<bool>> signedInQueue = new();
    private readonly LinkedList<TaskCompletionSource<bool>> guestQueue = new();
    private int running;
    private int guestsRunning;

    public async Task<bool> WaitAsync(ExecutionTier tier, TimeSpan timeout, CancellationToken cancellationToken)
    {
        LinkedListNode<TaskCompletionSource<bool>> node;
        lock (sync)
        {
            if (QueueFor(tier).Count == 0 && CanStart(tier))
            {
                Start(tier);
                return true;
            }
            node = QueueFor(tier).AddLast(new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously));
        }

        using var timeoutSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutSource.CancelAfter(timeout);
        using var registration = timeoutSource.Token.Register(() =>
        {
            lock (sync)
            {
                // A slot was already handed to this waiter; keep it.
                if (node.List is null) return;
                node.List.Remove(node);
            }
            node.Value.TrySetResult(false);
        });
        return await node.Value.Task;
    }

    public void Release(ExecutionTier tier)
    {
        lock (sync)
        {
            running--;
            if (tier == ExecutionTier.Guest) guestsRunning--;

            while (running < totalSlots)
            {
                if (signedInQueue.First is { } signedIn)
                {
                    Grant(signedInQueue, signedIn, ExecutionTier.SignedIn);
                }
                else if (guestQueue.First is { } guest && guestsRunning < guestSlots)
                {
                    Grant(guestQueue, guest, ExecutionTier.Guest);
                }
                else
                {
                    break;
                }
            }
        }
    }

    private LinkedList<TaskCompletionSource<bool>> QueueFor(ExecutionTier tier) =>
        tier == ExecutionTier.Guest ? guestQueue : signedInQueue;

    private bool CanStart(ExecutionTier tier) =>
        running < totalSlots &&
        (tier == ExecutionTier.SignedIn || (guestsRunning < guestSlots && signedInQueue.Count == 0));

    private void Start(ExecutionTier tier)
    {
        running++;
        if (tier == ExecutionTier.Guest) guestsRunning++;
    }

    private void Grant(LinkedList<TaskCompletionSource<bool>> queue, LinkedListNode<TaskCompletionSource<bool>> node, ExecutionTier tier)
    {
        queue.Remove(node);
        Start(tier);
        node.Value.TrySetResult(true);
    }
}
