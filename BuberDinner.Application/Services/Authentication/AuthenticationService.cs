namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Register(string firstName, string LastName, string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(), 
            firstName, 
            LastName, 
            email, 
            "token");
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