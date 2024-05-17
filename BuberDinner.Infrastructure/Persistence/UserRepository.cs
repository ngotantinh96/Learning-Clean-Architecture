using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    public static List<User> users = [];
    public void Add(User user)
    {
        users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return users.SingleOrDefault(x => x.Email == email);
    }
}