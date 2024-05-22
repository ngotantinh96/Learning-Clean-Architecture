using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        dbContext.Add(menu);
        dbContext.SaveChanges();
    }
}