using BuberDinner.Domain.Models;

namespace BuberDinner.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    public string Value { get; }

    public HostId(string value)
    {
        Value = value;
    }

    public static HostId Create(string hostId) => new(hostId);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}