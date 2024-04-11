using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDatetimeProvier
{
    public DateTime UtcNow => DateTime.UtcNow;
}