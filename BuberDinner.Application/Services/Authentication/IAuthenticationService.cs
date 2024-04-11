namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string username, string password);
    AuthenticationResult Register(string firstName, string LastName, string username, string password);
}