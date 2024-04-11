namespace BuberDinner.Infrastructure.Authentication;

public class JwtSettings
{
    public const string JwtSection = "JwtSettings";
    public string Issuer {get; init;} = null!;
    public string Audience {get; init;} = null!;
    public int ExpiryMinutes {get; init;} = 0;
    public string Secret {get; init;} = null!;
}