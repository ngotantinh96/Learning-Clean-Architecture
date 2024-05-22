using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.MenuReview;

public sealed class MenuReview : Entity<MenuReviewId>
{
    private MenuReview(MenuReviewId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }
    
    public static MenuReview Create(string name, string description)
        => new(MenuReviewId.CreateUnique(), name, description);
}