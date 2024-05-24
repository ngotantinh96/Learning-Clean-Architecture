using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    private Rating(double value)
    {
        Value = value;
    }

    private Rating()
    {
    }

    public double Value { get; private set; }

    public static Rating Create(double rating = 0)
        => new(rating);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}