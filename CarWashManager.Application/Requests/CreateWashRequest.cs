using MediatR;
using CarWashManager.Core.Dtos;

namespace CarWashManager.Application.Commands
{
    public class CreateWashRequest : IRequest<WashDto>
    {
        public string WashType { get; set; }
        public string Detergent { get; set; }
        public string ServiceType { get; set; }
        public string ServiceName { get; set; }
        public decimal Amount { get; set; }
        public DateTime WashTime { get; set; }

        public CreateWashRequest(string washType, string detergent, string serviceType, string serviceName, decimal amount, DateTime washTime)
        {
            WashType = washType;
            Detergent = detergent;
            ServiceType = serviceType;
            ServiceName = serviceName;
            Amount = amount;
            WashTime = washTime;
        }
    }
}
