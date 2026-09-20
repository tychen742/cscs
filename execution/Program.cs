using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

const int maxCellCount = 20;
const int maxCodeLength = 100_000;
const int maxStdinLength = 10_000;
const int executionTimeoutMilliseconds = 15_000;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");
var databaseConnectionString = Environment.GetEnvironmentVariable("CSCS_DB_CONNECTION")
    ?? throw new InvalidOperationException("CSCS_DB_CONNECTION must be set to a Postgres connection string.");
var dataProtectionPath = Environment.GetEnvironmentVariable("CSCS_DATA_PROTECTION_PATH") ?? "/tmp/cscs-keys";
Directory.CreateDirectory(dataProtectionPath);
var adminEmails = (Environment.GetEnvironmentVariable("CSCS_ADMIN_EMAILS") ?? string.Empty)
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(email => email.ToLowerInvariant())
    .ToHashSet(StringComparer.OrdinalIgnoreCase);
var exposePasswordResetLinks = builder.Environment.IsDevelopment() ||
    string.Equals(Environment.GetEnvironmentVariable("CSCS_EXPOSE_PASSWORD_RESET_LINKS"), "true", StringComparison.OrdinalIgnoreCase);
var logPasswordResetLinks = exposePasswordResetLinks ||
    string.Equals(Environment.GetEnvironmentVariable("CSCS_LOG_PASSWORD_RESET_LINKS"), "true", StringComparison.OrdinalIgnoreCase);
var exposeEmailVerificationLinks = builder.Environment.IsDevelopment() ||
    string.Equals(Environment.GetEnvironmentVariable("CSCS_EXPOSE_EMAIL_VERIFICATION_LINKS"), "true", StringComparison.OrdinalIgnoreCase);
var logEmailVerificationLinks = exposeEmailVerificationLinks ||
    string.Equals(Environment.GetEnvironmentVariable("CSCS_LOG_EMAIL_VERIFICATION_LINKS"), "true", StringComparison.OrdinalIgnoreCase);
var smtpHost = Environment.GetEnvironmentVariable("SMTP_HOST");
var smtpFrom = Environment.GetEnvironmentVariable("SMTP_FROM");
var smtpUsername = Environment.GetEnvironmentVariable("SMTP_USERNAME");
var smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD");
var smtpSecurity = Environment.GetEnvironmentVariable("SMTP_SECURITY") ?? "STARTTLS";
var smtpPort = int.TryParse(Environment.GetEnvironmentVariable("SMTP_PORT"), out var configuredSmtpPort)
    ? configuredSmtpPort
    : 587;
var allowedOrigins = (Environment.GetEnvironmentVariable("CSCS_ALLOWED_ORIGINS") ??
                      "https://thinkcscs.org,https://www.thinkcscs.org,http://localhost:3000,http://localhost:8000")
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
builder.Services.AddDbContext<CscsDbContext>(options => options.UseNpgsql(databaseConnectionString));
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
    database.Database.Migrate();
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

app.MapPost("/v1/admin/notebooks/save", async (NotebookSaveRequest request, ClaimsPrincipal principal, CscsDbContext database, NotebookRepository repository, CancellationToken cancellationToken) =>
{
    var email = principal.FindFirstValue(ClaimTypes.Email);
    if (!await CanAuthorAsync(email, database, cancellationToken)) return Results.Forbid();
    if (string.IsNullOrWhiteSpace(request.Path) || request.Content is null)
        return Results.BadRequest(new { error = "Path and content are required." });

    var result = await repository.SaveAsync(request.Path, request.Content, email!, cancellationToken);
    return result.Saved ? Results.Ok(result) : Results.BadRequest(result);
}).RequireAuthorization();

app.MapGet("/v1/admin/notebooks/source", async (string path, ClaimsPrincipal principal, CscsDbContext database, NotebookRepository repository, CancellationToken cancellationToken) =>
{
    var email = principal.FindFirstValue(ClaimTypes.Email);
    if (!await CanAuthorAsync(email, database, cancellationToken)) return Results.Forbid();
    var result = await repository.ReadAsync(path, cancellationToken);
    return result.Found
        ? Results.Content(result.Content!, "application/json")
        : Results.NotFound(new { error = result.Message });
}).RequireAuthorization();

app.MapPost("/v1/auth/register", async (RegisterRequest request, CscsDbContext database, HttpContext httpContext, ILogger<Program> logger) =>
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

    var now = DateTime.UtcNow;
    var user = new UserAccount
    {
        Email = email,
        DisplayName = displayName,
        PasswordHash = PasswordService.Hash(request.Password),
        Role = GetEffectiveRole(email, UserRole.Student),
        CreatedUtc = now,
        EmailVerifiedUtc = adminEmails.Contains(email) ? now : null
    };
    database.Users.Add(user);
    await database.SaveChangesAsync();

    if (user.EmailVerifiedUtc is null)
    {
        var token = PasswordService.CreateResetToken();
        database.EmailVerificationTokens.Add(new EmailVerificationToken
        {
            UserAccountId = user.Id,
            TokenHash = PasswordService.HashResetToken(token),
            CreatedUtc = now,
            ExpiresUtc = now.AddDays(2)
        });
        await database.SaveChangesAsync();

        var verificationUrl = BuildTokenUrl(request.PageUrl, httpContext.Request, "verifyToken", token);
        var emailSent = await SendEmailVerificationEmailAsync(user, verificationUrl, logger);
        if (!emailSent && logEmailVerificationLinks)
        {
            logger.LogInformation("Email verification link for {Email}: {VerificationUrl}", user.Email, verificationUrl);
        }

        return exposeEmailVerificationLinks
            ? Results.Created($"/v1/auth/me", new { user.Id, user.Email, user.DisplayName, message = "Account created. Check your email to verify your account before signing in.", verificationUrl, verificationToken = token })
            : Results.Created($"/v1/auth/me", new { user.Id, user.Email, user.DisplayName, message = "Account created. Check your email to verify your account before signing in." });
    }

    return Results.Created($"/v1/auth/me", new { user.Id, user.Email, user.DisplayName, message = "Account created. You may sign in now." });
});

app.MapPost("/v1/auth/login", async (LoginRequest request, CscsDbContext database, HttpContext httpContext) =>
{
    var email = request.Email?.Trim().ToLowerInvariant();
    var user = email is null ? null : await database.Users.SingleOrDefaultAsync(candidate => candidate.Email == email);
    if (user is null || string.IsNullOrWhiteSpace(request.Password) || !PasswordService.Verify(request.Password, user.PasswordHash))
    {
        return Results.Unauthorized();
    }
    if (user.EmailVerifiedUtc is null)
    {
        return Results.Json(new { error = "Check your email and verify your account before signing in." }, statusCode: StatusCodes.Status403Forbidden);
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

app.MapPost("/v1/auth/email-verification/confirm", async (EmailVerificationCompleteRequest request, CscsDbContext database) =>
{
    if (string.IsNullOrWhiteSpace(request.Token))
    {
        return Results.BadRequest(new { error = "Provide an email verification token." });
    }

    var tokenHash = PasswordService.HashResetToken(request.Token);
    var verificationToken = await database.EmailVerificationTokens
        .Include(token => token.UserAccount)
        .SingleOrDefaultAsync(token => token.TokenHash == tokenHash);
    if (verificationToken is null ||
        verificationToken.UserAccount is null ||
        verificationToken.UsedUtc is not null ||
        verificationToken.ExpiresUtc < DateTime.UtcNow)
    {
        return Results.BadRequest(new { error = "That email verification link is invalid or has expired." });
    }

    verificationToken.UserAccount.EmailVerifiedUtc ??= DateTime.UtcNow;
    verificationToken.UsedUtc = DateTime.UtcNow;
    await database.SaveChangesAsync();
    return Results.Ok(new { message = "Email verified. You can sign in now." });
});

app.MapPost("/v1/auth/password-reset/request", async (PasswordResetRequest request, CscsDbContext database, HttpContext httpContext, ILogger<Program> logger) =>
{
    var email = request.Email?.Trim().ToLowerInvariant();
    var message = "If an account exists for that email, a password reset link has been created.";
    if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
    {
        return Results.Ok(new { message });
    }

    var user = await database.Users.SingleOrDefaultAsync(candidate => candidate.Email == email);
    if (user is null)
    {
        return Results.Ok(new { message });
    }

    var now = DateTime.UtcNow;
    var token = PasswordService.CreateResetToken();
    database.PasswordResetTokens.Add(new PasswordResetToken
    {
        UserAccountId = user.Id,
        TokenHash = PasswordService.HashResetToken(token),
        CreatedUtc = now,
        ExpiresUtc = now.AddHours(2)
    });
    await database.SaveChangesAsync();

    var resetUrl = BuildTokenUrl(request.PageUrl, httpContext.Request, "resetToken", token);
    var emailSent = await SendPasswordResetEmailAsync(user, resetUrl, logger);
    if (!emailSent && logPasswordResetLinks)
    {
        logger.LogInformation("Password reset link for {Email}: {ResetUrl}", user.Email, resetUrl);
    }

    return exposePasswordResetLinks
        ? Results.Ok(new { message, resetUrl, resetToken = token })
        : Results.Ok(new { message });
});

app.MapPost("/v1/auth/password-reset/complete", async (PasswordResetCompleteRequest request, CscsDbContext database) =>
{
    if (string.IsNullOrWhiteSpace(request.Token) ||
        string.IsNullOrWhiteSpace(request.Password) ||
        request.Password.Length < 8)
    {
        return Results.BadRequest(new { error = "Provide a reset token and a password of at least 8 characters." });
    }

    var tokenHash = PasswordService.HashResetToken(request.Token);
    var resetToken = await database.PasswordResetTokens
        .Include(token => token.UserAccount)
        .SingleOrDefaultAsync(token => token.TokenHash == tokenHash);
    if (resetToken is null ||
        resetToken.UserAccount is null ||
        resetToken.UsedUtc is not null ||
        resetToken.ExpiresUtc < DateTime.UtcNow)
    {
        return Results.BadRequest(new { error = "That password reset link is invalid or has expired." });
    }

    resetToken.UserAccount.PasswordHash = PasswordService.Hash(request.Password);
    resetToken.UsedUtc = DateTime.UtcNow;
    await database.SaveChangesAsync();
    return Results.Ok(new { message = "Password reset. Sign in with your new password." });
});

app.MapPost("/v1/auth/logout", async (HttpContext httpContext) =>
{
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.NoContent();
});

app.MapGet("/v1/account/profile", async (ClaimsPrincipal principal, CscsDbContext database) =>
{
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userId, out var id)) return Results.Unauthorized();
    var user = await database.Users.FindAsync(id);
    if (user is null) return Results.Unauthorized();

    var role = GetEffectiveRole(user.Email, user.Role);
    return Results.Ok(ToAccountDto(user, role));
}).RequireAuthorization();

app.MapPut("/v1/account/profile", async (ProfileUpdateRequest request, ClaimsPrincipal principal, CscsDbContext database) =>
{
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userId, out var id)) return Results.Unauthorized();
    var user = await database.Users.FindAsync(id);
    if (user is null) return Results.Unauthorized();

    var displayName = request.DisplayName?.Trim();
    if (string.IsNullOrWhiteSpace(displayName) || displayName.Length > 120)
    {
        return Results.BadRequest(new { error = "Display name is required and must be 120 characters or fewer." });
    }

    user.DisplayName = displayName;
    await database.SaveChangesAsync();
    var role = GetEffectiveRole(user.Email, user.Role);
    return Results.Ok(ToAccountDto(user, role));
}).RequireAuthorization();

app.MapPut("/v1/account/password", async (PasswordChangeRequest request, ClaimsPrincipal principal, CscsDbContext database) =>
{
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userId, out var id)) return Results.Unauthorized();
    var user = await database.Users.FindAsync(id);
    if (user is null) return Results.Unauthorized();

    if (string.IsNullOrWhiteSpace(request.CurrentPassword) ||
        string.IsNullOrWhiteSpace(request.NewPassword) ||
        request.NewPassword.Length < 8)
    {
        return Results.BadRequest(new { error = "Provide your current password and a new password of at least 8 characters." });
    }

    if (!PasswordService.Verify(request.CurrentPassword, user.PasswordHash))
    {
        return Results.Json(new { error = "Current password is incorrect." }, statusCode: StatusCodes.Status403Forbidden);
    }

    user.PasswordHash = PasswordService.Hash(request.NewPassword);
    await database.SaveChangesAsync();
    return Results.Ok(new { message = "Password changed." });
}).RequireAuthorization();

app.MapGet("/v1/auth/me", async (ClaimsPrincipal principal, CscsDbContext database) =>
{
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userId, out var id)) return Results.Unauthorized();
    var user = await database.Users.FindAsync(id);
    if (user is null) return Results.Unauthorized();

    var role = GetEffectiveRole(user.Email, user.Role);
    return Results.Ok(ToAccountDto(user, role));
}).RequireAuthorization();

app.MapGet("/v1/admin/users", async (ClaimsPrincipal principal, CscsDbContext database, CancellationToken cancellationToken) =>
{
    if (!await CanManageUsersAsync(principal, database, cancellationToken)) return Results.Forbid();
    var users = await database.Users
        .OrderBy(user => user.Email)
        .ToListAsync(cancellationToken);
    return Results.Ok(users.Select(user => new
    {
        user.Id,
        user.Email,
        user.DisplayName,
        Role = GetEffectiveRole(user.Email, user.Role).ToString(),
        IsEmailVerified = user.EmailVerifiedUtc != null,
        user.CreatedUtc,
        user.EmailVerifiedUtc
    }));
}).RequireAuthorization();

app.MapPatch("/v1/admin/users/{id:int}", async (int id, UserRoleUpdateRequest request, ClaimsPrincipal principal, CscsDbContext database, CancellationToken cancellationToken) =>
{
    if (!await CanManageUsersAsync(principal, database, cancellationToken)) return Results.Forbid();
    var user = await database.Users.FindAsync([id], cancellationToken);
    if (user is null) return Results.NotFound(new { error = "User not found." });
    if (adminEmails.Contains(user.Email)) return Results.BadRequest(new { error = "Bootstrap admin role is controlled by CSCS_ADMIN_EMAILS." });
    if (!Enum.TryParse<UserRole>(request.Role, ignoreCase: true, out var role))
    {
        return Results.BadRequest(new { error = "Choose a valid role." });
    }

    user.Role = role;
    await database.SaveChangesAsync(cancellationToken);
    return Results.Ok(ToAccountDto(user, GetEffectiveRole(user.Email, user.Role)));
}).RequireAuthorization();

app.MapGet("/v1/progress/reading", async (ClaimsPrincipal principal, CscsDbContext database) =>
{
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userId, out var id)) return Results.Unauthorized();

    var progress = await database.ReadingProgress
        .Where(item => item.UserAccountId == id && item.BookId == "cscs")
        .SingleOrDefaultAsync();

    return progress is null
        ? Results.NoContent()
        : Results.Ok(new
        {
            progress.BookId,
            progress.PageUrl,
            progress.PageTitle,
            progress.ScrollY,
            progress.UpdatedUtc
        });
}).RequireAuthorization();

app.MapPost("/v1/progress/reading", async (ReadingProgressRequest request, ClaimsPrincipal principal, CscsDbContext database) =>
{
    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!int.TryParse(userId, out var id)) return Results.Unauthorized();

    var bookId = string.IsNullOrWhiteSpace(request.BookId) ? "cscs" : request.BookId.Trim();
    var pageUrl = request.PageUrl?.Trim();
    var pageTitle = request.PageTitle?.Trim();
    if (bookId.Length > 64 ||
        string.IsNullOrWhiteSpace(pageUrl) ||
        pageUrl.Length > 512 ||
        !pageUrl.StartsWith("/", StringComparison.Ordinal) ||
        string.IsNullOrWhiteSpace(pageTitle))
    {
        return Results.BadRequest(new { error = "A valid book ID, page URL, and page title are required." });
    }

    var progress = await database.ReadingProgress
        .Where(item => item.UserAccountId == id && item.BookId == bookId)
        .SingleOrDefaultAsync();

    if (progress is null)
    {
        progress = new ReadingProgress
        {
            UserAccountId = id,
            BookId = bookId,
            PageUrl = pageUrl,
            PageTitle = pageTitle[..Math.Min(pageTitle.Length, 240)],
            ScrollY = Math.Max(0, request.ScrollY),
            UpdatedUtc = DateTime.UtcNow
        };
        database.ReadingProgress.Add(progress);
    }
    else
    {
        progress.PageUrl = pageUrl;
        progress.PageTitle = pageTitle[..Math.Min(pageTitle.Length, 240)];
        progress.ScrollY = Math.Max(0, request.ScrollY);
        progress.UpdatedUtc = DateTime.UtcNow;
    }

    await database.SaveChangesAsync();
    return Results.Ok(new
    {
        progress.BookId,
        progress.PageUrl,
        progress.PageTitle,
        progress.ScrollY,
        progress.UpdatedUtc
    });
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

    if ((request.Stdin?.Length ?? 0) > maxStdinLength)
    {
        return Results.BadRequest(new { error = $"Input must be at most {maxStdinLength} characters." });
    }

    var source = BuildSource(cells.Select(NormalizeCell).ToList(), request.PrefixCellCount);
    var result = await ExecuteAsync(source, taskId, request.Stdin, cancellationToken);
    return Results.Ok(result);
});

app.Run();

async Task<bool> CanAuthorAsync(string? email, CscsDbContext database, CancellationToken cancellationToken)
{
    if (email is null) return false;
    if (adminEmails.Contains(email)) return true;
    var role = await database.Users
        .Where(user => user.Email == email)
        .Select(user => user.Role)
        .SingleOrDefaultAsync(cancellationToken);
    return CanAuthor(role);
}

async Task<bool> CanManageUsersAsync(ClaimsPrincipal principal, CscsDbContext database, CancellationToken cancellationToken)
{
    var email = principal.FindFirstValue(ClaimTypes.Email);
    if (email is null) return false;
    if (adminEmails.Contains(email)) return true;
    var role = await database.Users
        .Where(user => user.Email == email)
        .Select(user => user.Role)
        .SingleOrDefaultAsync(cancellationToken);
    return CanManageUsers(role);
}

UserRole GetEffectiveRole(string email, UserRole databaseRole) =>
    adminEmails.Contains(email) ? UserRole.Admin : databaseRole;

bool CanAuthor(UserRole role) =>
    role is UserRole.Admin or UserRole.Author or UserRole.Editor or UserRole.Instructor or UserRole.TA;

bool CanManageUsers(UserRole role) =>
    role is UserRole.Admin or UserRole.Instructor;

object ToAccountDto(UserAccount user, UserRole role) => new
{
    user.Id,
    user.Email,
    user.DisplayName,
    Role = role.ToString(),
    IsAdmin = role == UserRole.Admin,
    IsAuthor = role == UserRole.Author,
    IsEditor = role == UserRole.Editor,
    IsInstructor = role == UserRole.Instructor,
    IsTA = role == UserRole.TA,
    IsEmailVerified = user.EmailVerifiedUtc != null,
    CanAuthor = CanAuthor(role),
    CanManageUsers = CanManageUsers(role),
    Roles = GetRoleNames(role).ToArray()
};

IEnumerable<string> GetRoleNames(UserRole role)
{
    yield return role.ToString().ToLowerInvariant();
    if (CanAuthor(role)) yield return "authoring";
}

string BuildTokenUrl(string? pageUrl, HttpRequest request, string parameterName, string token)
{
    var baseUrl = GetAllowedResetPageUrl(pageUrl);
    if (baseUrl is null)
    {
        var origin = allowedOrigins.FirstOrDefault(origin => origin.StartsWith("https://thinkcscs.org", StringComparison.OrdinalIgnoreCase))
            ?? allowedOrigins.FirstOrDefault()
            ?? $"{request.Scheme}://{request.Host}";
        baseUrl = $"{origin.TrimEnd('/')}/";
    }

    var separator = baseUrl.Contains('?', StringComparison.Ordinal) ? "&" : "?";
    return $"{baseUrl}{separator}{parameterName}={Uri.EscapeDataString(token)}";
}

string? GetAllowedResetPageUrl(string? pageUrl)
{
    if (string.IsNullOrWhiteSpace(pageUrl)) return null;
    if (!Uri.TryCreate(pageUrl, UriKind.Absolute, out var uri)) return null;

    var origin = $"{uri.Scheme}://{uri.Authority}";
    if (!allowedOrigins.Contains(origin, StringComparer.OrdinalIgnoreCase)) return null;

    var builder = new UriBuilder(uri)
    {
        Fragment = string.Empty,
        Query = string.Empty
    };
    return builder.Uri.ToString();
}

async Task<bool> SendPasswordResetEmailAsync(UserAccount user, string resetUrl, ILogger logger)
{
    if (string.IsNullOrWhiteSpace(smtpHost) ||
        string.IsNullOrWhiteSpace(smtpFrom) ||
        string.IsNullOrWhiteSpace(smtpUsername) ||
        string.IsNullOrWhiteSpace(smtpPassword))
    {
        return false;
    }

    try
    {
        using var message = new MailMessage(smtpFrom, user.Email)
        {
            Subject = "Think CS C# password reset",
            Body = $"""
Hi {user.DisplayName},

Use this link to reset your Think CS C# course account password:

{resetUrl}

This link expires in 2 hours. If you did not request a password reset, you can ignore this email.
"""
        };

#pragma warning disable SYSLIB0014
        using var client = new SmtpClient(smtpHost, smtpPort)
        {
            DeliveryMethod = SmtpDeliveryMethod.Network,
            EnableSsl = smtpSecurity.Equals("STARTTLS", StringComparison.OrdinalIgnoreCase) ||
                        smtpSecurity.Equals("SSL", StringComparison.OrdinalIgnoreCase) ||
                        smtpSecurity.Equals("true", StringComparison.OrdinalIgnoreCase),
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(smtpUsername, smtpPassword)
        };
        await client.SendMailAsync(message);
#pragma warning restore SYSLIB0014
        return true;
    }
    catch (Exception exception)
    {
        logger.LogError(exception, "Unable to send password reset email for {Email}", user.Email);
        return false;
    }
}

async Task<bool> SendEmailVerificationEmailAsync(UserAccount user, string verificationUrl, ILogger logger)
{
    if (string.IsNullOrWhiteSpace(smtpHost) ||
        string.IsNullOrWhiteSpace(smtpFrom) ||
        string.IsNullOrWhiteSpace(smtpUsername) ||
        string.IsNullOrWhiteSpace(smtpPassword))
    {
        return false;
    }

    try
    {
        using var message = new MailMessage(smtpFrom, user.Email)
        {
            Subject = "Verify your Think CS C# account",
            Body = $"""
Hi {user.DisplayName},

Use this link to verify your Think CS C# course account:

{verificationUrl}

This link expires in 2 days. If you did not create this account, you can ignore this email.
"""
        };

#pragma warning disable SYSLIB0014
        using var client = new SmtpClient(smtpHost, smtpPort)
        {
            DeliveryMethod = SmtpDeliveryMethod.Network,
            EnableSsl = smtpSecurity.Equals("STARTTLS", StringComparison.OrdinalIgnoreCase) ||
                        smtpSecurity.Equals("SSL", StringComparison.OrdinalIgnoreCase) ||
                        smtpSecurity.Equals("true", StringComparison.OrdinalIgnoreCase),
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(smtpUsername, smtpPassword)
        };
        await client.SendMailAsync(message);
#pragma warning restore SYSLIB0014
        return true;
    }
    catch (Exception exception)
    {
        logger.LogError(exception, "Unable to send email verification email for {Email}", user.Email);
        return false;
    }
}

static async Task<ExecutionResult> ExecuteAsync(string source, string taskId, string? stdin, CancellationToken cancellationToken)
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
            RedirectStandardInput = true,
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

        await process.StandardInput.WriteAsync(stdin ?? string.Empty);
        process.StandardInput.Close();

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
