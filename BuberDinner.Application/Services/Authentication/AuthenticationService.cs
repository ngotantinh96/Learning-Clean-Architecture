using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

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

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if(userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception($"User with email: {email} is already existed!");
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

    public AuthenticationResult Login(string email, string password)
    {
        if(userRepository.GetUserByEmail(email) is not User user) 
        {
              throw new Exception($"User with email: {email} is not existed!");
        }

        if(user.Password != password)
        {
            throw new Exception("Incorrect password!");
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