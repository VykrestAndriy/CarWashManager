using System;
using CarWashManager.Infrastructure.Enums;

namespace CarWashManager.BusinessLogic.Dtos;

public class WashDto : IEquatable<WashDto>, ICloneable
{
    public static readonly WashDto Default
        = new WashDto(string.Empty, WashType.FullService, string.Empty, ServiceType.ExteriorWash, string.Empty, decimal.Zero, DateTime.MinValue, DateTime.MinValue);

    public string WashId { get; }
    public WashType WashType { get; }
    public ServiceType ServiceType { get; }
    public string ServiceName { get; }
    public decimal Amount { get; }
    public DateTime WashTime { get; }
    public string Detergent { get; set; }
    public DateTime StartTime { get; }

    public WashDto(string washId, WashType washType, string detergent, ServiceType serviceType, string serviceName, decimal amount, DateTime washTime, DateTime startTime)
    {
        WashId = washId;
        WashType = washType;
        Detergent = detergent;
        ServiceType = serviceType;
        ServiceName = serviceName;
        Amount = amount;
        WashTime = washTime;
        StartTime = startTime;
    }

    public WashDto Clone()
    {
        return new WashDto(
            this.WashId,
            this.WashType,
            this.Detergent,
            this.ServiceType,
            this.ServiceName,
            this.Amount,
            this.WashTime,
            this.StartTime
        );
    }

    object ICloneable.Clone()
    {
        return Clone();
    }

    public bool Equals(WashDto? other)
    {
        if (other == null)
            return false;

        return string.Equals(WashId, other.WashId) &&
               WashType == other.WashType &&
               ServiceType == other.ServiceType &&
               string.Equals(ServiceName, other.ServiceName) &&
               Amount == other.Amount &&
               WashTime == other.WashTime &&
               string.Equals(Detergent, other.Detergent) &&
               StartTime == other.StartTime;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(WashId, WashType, ServiceType, ServiceName, Amount, WashTime, Detergent, StartTime);
    }
}
