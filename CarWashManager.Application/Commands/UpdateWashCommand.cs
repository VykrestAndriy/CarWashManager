using MediatR;
using System;

namespace CarWashManager.Application.Commands.Wash
{
    public class UpdateWashCommand : IRequest<bool>
    {
        public Guid WashId { get; set; }
        public string WashType { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public DateTime WashTime { get; set; }
        public string Detergent { get; set; } 
        public UpdateWashCommand(Guid washId, string washType, string serviceType, string serviceName, decimal amount, DateTime washTime, string detergent)
        {
            WashId = washId;
            WashType = washType;
            ServiceType = serviceType;
            ServiceName = serviceName;
            Amount = amount;
            WashTime = washTime;
            Detergent = detergent;  
        }
    }
}
