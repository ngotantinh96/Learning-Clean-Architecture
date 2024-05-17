using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Common.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;
    private readonly IUserRepository userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
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