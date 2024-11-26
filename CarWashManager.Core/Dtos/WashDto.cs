using CarWashManager.Core.Enums;

public class WashDto : IEquatable<WashDto>, ICloneable
{
    public string WashId { get; }
    public WashType WashType { get; private set; }
    public ServiceType ServiceType { get; private set; }
    public string ServiceName { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime WashTime { get; private set; }
    public string Detergent { get; set; }
    public DateTime StartTime { get; private set; }

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

    public void UpdateWashDetails(WashType washType, ServiceType serviceType, string serviceName, decimal amount, DateTime washTime)
    {
        WashType = washType;
        ServiceType = serviceType;
        ServiceName = serviceName;
        Amount = amount;
        WashTime = washTime;
    }

    public bool Equals(WashDto? other)
    {
        if (other == null) return false;
        return WashId == other.WashId;
    }

    public object Clone()
    {
        return new WashDto(WashId, WashType, Detergent, ServiceType, ServiceName, Amount, WashTime, StartTime);
    }

    public void UpdateAmount(decimal v)
    {
        throw new NotImplementedException();
    }

    public void AddAmount(int v)
    {
        throw new NotImplementedException();
    }

    public static WashDto Default => new WashDto(string.Empty, WashType.Unknown, string.Empty, ServiceType.Unknown, string.Empty, 0, DateTime.MinValue, DateTime.MinValue);
}
