using MediatR;
using System;

namespace CarWashManager.Application.Commands.Wash
{
    public class CreateWashCommand : IRequest<Guid>
    {
        public string WashType { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public DateTime WashTime { get; set; }
        public string Detergent { get; set; }

        public CreateWashCommand(string washType, string serviceType, string serviceName, decimal amount, DateTime washTime, string detergent)
        {
            WashType = washType;
            ServiceType = serviceType;
            ServiceName = serviceName;
            Amount = amount;
            WashTime = washTime;
            Detergent = detergent;
        }
    }
}
