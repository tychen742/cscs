using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

public sealed class CscsDbContext(DbContextOptions<CscsDbContext> options) : DbContext(options)
{
    public DbSet<UserAccount> Users => Set<UserAccount>();
    public DbSet<ReadingProgress> ReadingProgress => Set<ReadingProgress>();
    public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReadingProgress>()
            .HasIndex(progress => new { progress.UserAccountId, progress.BookId })
            .IsUnique();
        modelBuilder.Entity<PasswordResetToken>()
            .HasIndex(token => token.TokenHash)
            .IsUnique();
    }
}

public sealed class UserAccount
{
    public int Id { get; set; }

    [MaxLength(320)]
    public required string Email { get; set; }

    [MaxLength(120)]
    public required string DisplayName { get; set; }

    [MaxLength(512)]
    public required string PasswordHash { get; set; }

    [MaxLength(64)]
    public string BookId { get; set; } = "cscs";

    [MaxLength(64)]
    public string? CourseId { get; set; }

    public UserRole Role { get; set; } = UserRole.Student;

    public DateTime CreatedUtc { get; set; }

    public List<ReadingProgress> ReadingProgress { get; set; } = [];
}

public enum UserRole
{
    Student = 0,
    TA = 10,
    Instructor = 20,
    Editor = 30,
    Author = 40,
    Admin = 50
}

public sealed class ReadingProgress
{
    public int Id { get; set; }

    public int UserAccountId { get; set; }

    public UserAccount? UserAccount { get; set; }

    [MaxLength(64)]
    public string BookId { get; set; } = "cscs";

    [MaxLength(512)]
    public required string PageUrl { get; set; }

    [MaxLength(240)]
    public required string PageTitle { get; set; }

    public int ScrollY { get; set; }

    public DateTime UpdatedUtc { get; set; }
}

public sealed class PasswordResetToken
{
    public int Id { get; set; }

    public int UserAccountId { get; set; }

    public UserAccount? UserAccount { get; set; }

    [MaxLength(128)]
    public required string TokenHash { get; set; }

    public DateTime CreatedUtc { get; set; }

    public DateTime ExpiresUtc { get; set; }

    public DateTime? UsedUtc { get; set; }
}

public static class PasswordService
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 100_000;

    public static string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var key = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);
        return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(key)}";
    }

    public static bool Verify(string password, string encodedHash)
    {
        var parts = encodedHash.Split('.', 3);
        if (parts.Length != 3 || !int.TryParse(parts[0], out var iterations)) return false;

        try
        {
            var salt = Convert.FromBase64String(parts[1]);
            var expected = Convert.FromBase64String(parts[2]);
            var actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static string CreateResetToken()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(32)).ToLowerInvariant();
    }

    public static string HashResetToken(string token)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(token.Trim()));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }
}

public sealed record RegisterRequest(string? Email, string? Password, string? DisplayName);
public sealed record LoginRequest(string? Email, string? Password);
public sealed record PasswordResetRequest(string? Email, string? PageUrl);
public sealed record PasswordResetCompleteRequest(string? Token, string? Password);
public sealed record ReadingProgressRequest(string? BookId, string? PageUrl, string? PageTitle, int ScrollY);
