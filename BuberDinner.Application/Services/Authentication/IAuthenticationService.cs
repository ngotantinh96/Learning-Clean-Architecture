using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string username, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string username, string password);
}