using CarWashManager.Core.Enums;
using System;

namespace CarWashManager.Application.Factories
{ 
    public class WashOrderForTakeaway : IWashOrder
    {
        public string OrderId { get; private set; }
        public string WashType { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime OrderTime { get; private set; }

        public WashOrderForTakeaway(string orderId, string washType, decimal amount)
        {
            OrderId = orderId;
            WashType = washType;
            Amount = amount;
            OrderTime = DateTime.UtcNow;
        }

        public void ProcessOrder()
        {
            Console.WriteLine($"Processing takeaway wash order: order №{OrderId} - {WashType} wash for {Amount:C}");
        }
    }

    public abstract class IWashOrderFactory  
    {
        public abstract IWashOrder CreateOrder(string orderId, string washType, decimal amount);
    }

    public class WashOrderForTakeawayFactory : IWashOrderFactory  
    {
        public override IWashOrder CreateOrder(string orderId, string washType, decimal amount)
        {
            return new WashOrderForTakeaway(orderId, washType, amount);
        }
    }
}
