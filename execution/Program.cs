using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

const int maxCellCount = 20;
const int maxCodeLength = 100_000;
const int executionTimeoutMilliseconds = 15_000;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");
var databasePath = Environment.GetEnvironmentVariable("CSCS_DB_PATH") ?? "/tmp/cscs.db";
Directory.CreateDirectory(Path.GetDirectoryName(databasePath) ?? "/tmp");
var dataProtectionPath = Environment.GetEnvironmentVariable("CSCS_DATA_PROTECTION_PATH") ?? "/tmp/cscs-keys";
Directory.CreateDirectory(dataProtectionPath);
var adminEmails = (Environment.GetEnvironmentVariable("CSCS_ADMIN_EMAILS") ?? string.Empty)
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(email => email.ToLowerInvariant())
    .ToHashSet(StringComparer.OrdinalIgnoreCase);
var allowedOrigins = (Environment.GetEnvironmentVariable("CSCS_ALLOWED_ORIGINS") ??
                      "https://thinkcscs.org,https://www.thinkcscs.org,http://localhost:3000,http://localhost:8000")
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
builder.Services.AddDbContext<CscsDbContext>(options => options.UseSqlite($"Data Source={databasePath}"));
builder.Services.AddSingleton<NotebookRepository>();
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(dataProtectionPath))
    .SetApplicationName("thinkcscs");
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "cscs_auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.LoginPath = "/v1/auth/login";
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<CscsDbContext>();
    database.Database.EnsureCreated();
}
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => Results.Ok(new
{
    service = "CSCS execution API",
    status = "ok",
    health = "/health"
}));

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapPost("/v1/admin/notebooks/validate", async (HttpRequest request) =>
{
    try
    {
        using var document = await JsonDocument.ParseAsync(request.Body, cancellationToken: request.HttpContext.RequestAborted);
        var result = NotebookValidation.Validate(document.RootElement.GetRawText());
        return result.IsValid
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
    catch (JsonException exception)
    {
        return Results.BadRequest(NotebookValidationResult.Invalid($"Invalid JSON: {exception.Message}"));
    }
});

app.MapPost("/v1/admin/notebooks/save", async (NotebookSaveRequest request, ClaimsPrincipal principal, NotebookRepository repository, CancellationToken cancellationToken) =>
{
    var email = principal.FindFirstValue(ClaimTypes.Email);
    if (!IsAdmin(email)) return Results.Forbid();
    if (string.IsNullOrWhiteSpace(request.Path) || request.Content is null)
        return Results.BadRequest(new { error = "Path and content are required." });

    var result = await repository.SaveAsync(request.Path, request.Content, email, cancellationToken);
    return result.Saved ? Results.Ok(result) : Results.BadRequest(result);
}).RequireAuthorization();

app.MapGet("/v1/admin/notebooks/source", async (string path, ClaimsPrincipal principal, NotebookRepository repository, CancellationToken cancellationToken) =>
{
    var email = principal.FindFirstValue(ClaimTypes.Email);
    if (!IsAdmin(email)) return Results.Forbid();
    var result = await repository.ReadAsync(path, cancellationToken);
    return result.Found
        ? Results.Content(result.Content!, "application/json")
        : Results.NotFound(new { error = result.Message });
}).RequireAuthorization();

app.MapPost("/v1/auth/register", async (RegisterRequest request, CscsDbContext database) =>
{
    var email = request.Email?.Trim().ToLowerInvariant();
    var displayName = request.DisplayName?.Trim();
    if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') ||
        string.IsNullOrWhiteSpace(displayName) || displayName.Length > 120 ||
        string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 8)
    {
        return Results.BadRequest(new { error = "Provide a valid email, display name, and password of at least 8 characters." });
    }

    if (await database.Users.AnyAsync(user => user.Email == email))
    {
        return Results.Conflict(new { error = "An account with that email already exists." });
    }

    var user = new UserAccount
    {
        Email = email,
        DisplayName = displayName,
        PasswordHash = PasswordService.Hash(request.Password),
        CreatedUtc = DateTime.UtcNow
    };
    database.Users.Add(user);
    await database.SaveChangesAsync();
    return Results.Created($"/v1/auth/me", new { user.Id, user.Email, user.DisplayName });
});

app.MapPost("/v1/auth/login", async (LoginRequest request, CscsDbContext database, HttpContext httpContext) =>
{
    var email = request.Email?.Trim().ToLowerInvariant();
    var user = email is null ? null : await database.Users.SingleOrDefaultAsync(candidate => candidate.Email == email);
    if (user is null || string.IsNullOrWhiteSpace(request.Password) || !PasswordService.Verify(request.Password, user.PasswordHash))
    {
        return Results.Unauthorized();
    }

    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.DisplayName)
    };
    await httpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));
    return Results.Ok(new { user.Id, user.Email, user.DisplayName });
});

app.MapPost("/v1/auth/logout", async (HttpContext httpContext) =>
{
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.NoContent();
});

app.MapGet("/v1/auth/me", async (ClaimsPrincipal principal, CscsDbContext database) =>
{
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userId, out var id)) return Results.Unauthorized();
    var user = await database.Users.FindAsync(id);
    return user is null
        ? Results.Unauthorized()
    : Results.Ok(new { user.Id, user.Email, user.DisplayName, IsAdmin = adminEmails.Contains(user.Email) });
}).RequireAuthorization();

app.MapPost("/v1/tasks/{taskId}/execute", async (string taskId, ExecutionRequest request, CancellationToken cancellationToken) =>
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

    var source = BuildSource(cells.Select(NormalizeCell).ToList(), request.PrefixCellCount);
    var result = await ExecuteAsync(source, taskId, cancellationToken);
    return Results.Ok(result);
});

app.Run();

bool IsAdmin(string? email) => email is not null && adminEmails.Contains(email);

static async Task<ExecutionResult> ExecuteAsync(string source, string taskId, CancellationToken cancellationToken)
{
    var executionDirectory = Path.Combine(Path.GetTempPath(), $"cscs-{Guid.NewGuid():N}");
    DirectoryCopy("/app/runner-template", executionDirectory);
    await File.WriteAllTextAsync(Path.Combine(executionDirectory, "Program.cs"), source, cancellationToken);

    try
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            WorkingDirectory = executionDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        startInfo.ArgumentList.Add("run");
        startInfo.ArgumentList.Add("--no-restore");
        startInfo.ArgumentList.Add("-p:UseAppHost=false");
        startInfo.ArgumentList.Add("--project");
        startInfo.ArgumentList.Add(Path.Combine(executionDirectory, "runner-template.csproj"));

        using var process = Process.Start(startInfo);
        if (process is null)
        {
            return new ExecutionResult(taskId, string.Empty, "Unable to start the C# compiler.", -1, false);
        }

        using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeout.CancelAfter(executionTimeoutMilliseconds);

        try
        {
            await process.WaitForExitAsync(timeout.Token);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            process.Kill(entireProcessTree: true);
            await process.WaitForExitAsync(CancellationToken.None);
            return new ExecutionResult(
                taskId,
                await process.StandardOutput.ReadToEndAsync(),
                "Execution timed out after 15 seconds.",
                -1,
                true);
        }

        var output = CleanOutput(await process.StandardOutput.ReadToEndAsync());
        var error = await process.StandardError.ReadToEndAsync();
        return new ExecutionResult(taskId, output, error, process.ExitCode, false);
    }
    finally
    {
        Directory.Delete(executionDirectory, recursive: true);
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
        return string.Join(Environment.NewLine, usingLines) + Environment.NewLine + WrapLooseMembers(current);
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
        if (Regex.IsMatch(line, "^\\s*using\\s+.+;\\s*$"))
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
            ? Environment.NewLine + "    public static void Main(string[] args) => main(args);" + Environment.NewLine
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

public sealed record ExecutionRequest(string? Code, List<string>? Cells, int PrefixCellCount = 0);

public sealed record ExecutionResult(string TaskId, string Output, string Error, int ExitCode, bool TimedOut);
