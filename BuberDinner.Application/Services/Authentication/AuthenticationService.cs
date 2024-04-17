using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if(userRepository.GetUserByEmail(email) is not null)
        {
            // throw new Exception($"User with email: {email} is already existed!");
            // throw new DuplicateEmailException();
            // return new DuplicateEmailError();
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        userRepository.Add(user);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user.Id, 
            firstName, 
            lastName, 
            email, 
            token);
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if(userRepository.GetUserByEmail(email) is not User user) 
        {
            //   throw new Exception($"User with email: {email} is not existed!");
            return Errors.Authentication.InvalidCredentials;
        }

        if(user.Password != password)
        {
            // throw new Exception("Incorrect password!");
            return Errors.Authentication.InvalidCredentials;
        }

         var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user.Id, 
            user.FirstName, 
            user.LastName, 
            user.Email, 
            token);
    }
}