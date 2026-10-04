using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

/// <summary>A verified Press pass: the Press user ID, plus role and email on author passes.</summary>
public sealed record PressPass(string Subject, string? Role, string? Email);

/// <summary>
/// Checks passes signed by Press: compact JWS, ES256, 64-byte r || s signature.
/// See press/docs/RUN_PASSES.md; press/assignments/run_pass.py is the reference.
/// Holds only public keys, so code that can read this process's memory still cannot mint
/// passes. Any malformed, unsigned, expired, or foreign pass yields null.
/// </summary>
public sealed class PressPassVerifier
{
    private const int ClockSkewSeconds = 60;
    private const int MaxTokenLength = 4096;
    private readonly Dictionary<string, ECDsa> keys;
    private readonly string audience;
    private readonly string book;
    private readonly string tier;

    private PressPassVerifier(Dictionary<string, ECDsa> keys, string audience, string book, string tier)
    {
        this.keys = keys;
        this.audience = audience;
        this.book = book;
        this.tier = tier;
    }

    public int KeyCount => keys.Count;

    /// <summary>
    /// Public keys as a comma-separated list; each is a PEM block or its bare base64 body
    /// (SubjectPublicKeyInfo DER). Several keys allow rotation without downtime.
    /// </summary>
    public static PressPassVerifier FromConfiguration(string? publicKeys, string audience, string book, string tier)
    {
        var keys = new Dictionary<string, ECDsa>(StringComparer.Ordinal);
        foreach (var entry in (publicKeys ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            var der = Convert.FromBase64String(Regex.Replace(entry, "-----(BEGIN|END) PUBLIC KEY-----|\\s", string.Empty));
            var key = ECDsa.Create();
            key.ImportSubjectPublicKeyInfo(der, out _);
            if (key.KeySize != 256)
            {
                throw new InvalidOperationException("Press pass public keys must be ECDSA P-256.");
            }
            keys[KeyId(der)] = key;
        }
        return new PressPassVerifier(keys, audience, book, tier);
    }

    /// <summary>Matches Press: first 16 characters of base64url(SHA-256(SubjectPublicKeyInfo DER)).</summary>
    public static string KeyId(byte[] subjectPublicKeyInfo) => ToBase64Url(SHA256.HashData(subjectPublicKeyInfo))[..16];

    /// <summary>Returns the verified pass, or null if it is missing or invalid.</summary>
    public PressPass? Verify(string? token, DateTimeOffset now)
    {
        if (string.IsNullOrEmpty(token) || keys.Count == 0 || token.Length > MaxTokenLength) return null;
        var parts = token.Split('.');
        if (parts.Length != 3) return null;
        try
        {
            using var header = JsonDocument.Parse(FromBase64Url(parts[0]));
            if (header.RootElement.GetProperty("alg").GetString() != "ES256") return null;
            if (!keys.TryGetValue(header.RootElement.GetProperty("kid").GetString() ?? string.Empty, out var key)) return null;

            var signature = FromBase64Url(parts[2]);
            if (signature.Length != 64) return null;
            var signedBytes = Encoding.ASCII.GetBytes(parts[0] + "." + parts[1]);
            bool signatureValid;
            lock (key)
            {
                signatureValid = key.VerifyData(signedBytes, signature, HashAlgorithmName.SHA256, DSASignatureFormat.IeeeP1363FixedFieldConcatenation);
            }
            if (!signatureValid) return null;

            using var claimsDocument = JsonDocument.Parse(FromBase64Url(parts[1]));
            var claims = claimsDocument.RootElement;
            if (claims.GetProperty("aud").GetString() != audience) return null;
            if (claims.GetProperty("book").GetString() != book) return null;
            if (claims.GetProperty("tier").GetString() != tier) return null;
            var current = now.ToUnixTimeSeconds();
            if (claims.GetProperty("exp").GetInt64() + ClockSkewSeconds < current) return null;
            if (claims.GetProperty("iat").GetInt64() - ClockSkewSeconds > current) return null;
            var subject = claims.GetProperty("sub").GetString();
            if (string.IsNullOrEmpty(subject)) return null;
            return new PressPass(subject, OptionalString(claims, "role"), OptionalString(claims, "email"));
        }
        catch (Exception exception) when (exception is FormatException or JsonException or KeyNotFoundException or InvalidOperationException or CryptographicException)
        {
            return null;
        }
    }

    private static string? OptionalString(JsonElement claims, string name) =>
        claims.TryGetProperty(name, out var value) && value.ValueKind == JsonValueKind.String ? value.GetString() : null;

    private static string ToBase64Url(byte[] data) =>
        Convert.ToBase64String(data).TrimEnd('=').Replace('+', '-').Replace('/', '_');

    private static byte[] FromBase64Url(string text)
    {
        var base64 = text.Replace('-', '+').Replace('_', '/');
        return Convert.FromBase64String(base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '='));
    }
}
