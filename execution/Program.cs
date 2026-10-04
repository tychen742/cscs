using System.Text.Json;

// CSCS browser-authoring API: lets Press authors load, save, and commit book notebooks
// from the book page. Accounts live in Press; each request carries a short-lived author
// pass signed by Press (press/docs/RUN_PASSES.md), checked here with Press's public key.
// Student code never runs here; see runner/.

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");
var allowedOrigins = (Environment.GetEnvironmentVariable("CSCS_ALLOWED_ORIGINS") ??
                      "https://cscs.thinkpress.org,https://thinkcscs.org,https://www.thinkcscs.org,http://localhost:3000,http://localhost:8000")
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
// No credentials: authorization travels in the Authorization header, not in cookies.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins(allowedOrigins).AllowAnyHeader().WithMethods("GET", "POST")));
builder.Services.AddSingleton<NotebookRepository>();
builder.Services.AddSingleton<GitRepository>();

var authorPassVerifier = PressPassVerifier.FromConfiguration(
    Environment.GetEnvironmentVariable("CSCS_RUN_PASS_PUBLIC_KEYS"),
    Environment.GetEnvironmentVariable("CSCS_AUTHOR_PASS_AUDIENCE") ?? "cscs-authoring",
    Environment.GetEnvironmentVariable("CSCS_RUN_PASS_BOOK") ?? "cscs",
    "author");
// Press roles allowed to author (Press issues author passes only to these, too).
var authorRoles = new HashSet<string>(StringComparer.Ordinal) { "admin", "author", "editor", "instructor", "ta" };

var app = builder.Build();
app.Logger.LogInformation("Author passes: {KeyCount} public key(s) configured", authorPassVerifier.KeyCount);
app.UseCors();

app.MapGet("/", () => Results.Ok(new
{
    service = "CSCS authoring API",
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

app.MapPost("/v1/admin/notebooks/save", async (NotebookSaveRequest request, HttpRequest http, NotebookRepository repository, CancellationToken cancellationToken) =>
{
    var (author, denied) = Authorize(http);
    if (denied is not null) return denied;
    if (string.IsNullOrWhiteSpace(request.Path) || request.Content is null)
        return Results.BadRequest(new { error = "Path and content are required." });

    var result = await repository.SaveAsync(request.Path, request.Content, author!.Email ?? author.Subject, cancellationToken);
    return result.Saved ? Results.Ok(result) : Results.BadRequest(result);
});

app.MapGet("/v1/admin/notebooks/source", async (string path, HttpRequest http, NotebookRepository repository, CancellationToken cancellationToken) =>
{
    var (_, denied) = Authorize(http);
    if (denied is not null) return denied;
    var result = await repository.ReadAsync(path, cancellationToken);
    return result.Found
        ? Results.Content(result.Content!, "application/json")
        : Results.NotFound(new { error = result.Message });
});

app.MapPost("/v1/admin/git/sync", async (GitSyncRequest request, HttpRequest http, GitRepository repository, CancellationToken cancellationToken) =>
{
    var (author, denied) = Authorize(http);
    if (denied is not null) return denied;
    var result = await repository.SyncAsync(author!.Email ?? string.Empty, request.Message, cancellationToken);
    return result.Synced ? Results.Ok(result) : Results.BadRequest(result);
});

app.Run();

// A valid author pass with an authoring role, or the response to send instead.
(PressPass? Author, IResult? Denied) Authorize(HttpRequest request)
{
    var header = request.Headers.Authorization.ToString();
    var token = header.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) ? header["Bearer ".Length..].Trim() : null;
    var pass = authorPassVerifier.Verify(token, DateTimeOffset.UtcNow);
    if (pass is null)
        return (null, Results.Json(new { error = "Sign in with an author account to edit this book." }, statusCode: StatusCodes.Status401Unauthorized));
    if (pass.Role is null || !authorRoles.Contains(pass.Role))
        return (null, Results.Json(new { error = "Your account cannot author this book." }, statusCode: StatusCodes.Status403Forbidden));
    return (pass, null);
}
