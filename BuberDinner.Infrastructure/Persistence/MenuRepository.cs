using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    public static readonly List<Menu> _menus = [];
    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }
}