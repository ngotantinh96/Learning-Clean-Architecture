using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string firstName, string LastName, string email, string password)
    {
        var userId = Guid.NewGuid();
        var token = jwtTokenGenerator.GenerateToken(userId, firstName, LastName);

        return new AuthenticationResult(
            userId, 
            firstName, 
            LastName, 
            email, 
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            "firstName", 
            "LastName", 
            email, 
            "token");
    }
}