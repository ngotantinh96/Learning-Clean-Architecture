using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public Rating(double value)
    {
        Value = value;
    }

    public double Value { get; private set; }

    public static Rating Create(double rating = 0)
        => new(rating);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}