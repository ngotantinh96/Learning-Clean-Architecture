using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Entities;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BuberDinnerDbContext dbContext;

    public UserRepository(BuberDinnerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Add(User user)
    {
        dbContext.Add(user);
        dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return dbContext.Users.SingleOrDefault(x => x.Email == email);
    }
}