using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique() => new(Guid.NewGuid());
    
    public static MenuId Create(Guid value) => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}