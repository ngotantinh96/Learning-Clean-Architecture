using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

public sealed class MenuReview : Entity<MenuReviewId>
{
    private MenuReview(MenuReviewId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private MenuReview()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public static MenuReview Create(string name, string description)
        => new(MenuReviewId.CreateUnique(), name, description);
}