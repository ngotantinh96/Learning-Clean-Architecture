using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    private MenuReviewId()
    {
    }

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}