namespace BuberDinner.Application.Common.Interfaces.Services;

public interface IDatetimeProvier
{
    DateTime UtcNow { get; }
}