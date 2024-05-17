using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public sealed class AverageRatting : ValueObject
{
    public float Value { get; }

    public AverageRatting(float value)
    {
        Value = value;
    }

    public static AverageRatting Create(float rating) => new(rating);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}