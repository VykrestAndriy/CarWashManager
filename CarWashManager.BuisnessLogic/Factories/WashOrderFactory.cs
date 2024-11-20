using CarWashManager.DataAccess.Entities;
using System;

namespace CarWashManager.BuisnessLogic.Factories
{
    // Інтерфейс для замовлення на миття
    public interface IWashOrder
    {
        string OrderId { get; }
        string WashType { get; }
        decimal Amount { get; }
        DateTime OrderTime { get; }
        void ProcessOrder();
    }

    // Клас для замовлення на миття
    public class WashOrder : IWashOrder
    {
        public string OrderId { get; private set; }
        public string WashType { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime OrderTime { get; private set; }

        public WashOrder(string orderId, string washType, decimal amount)
        {
            OrderId = orderId;
            WashType = washType;
            Amount = amount;
            OrderTime = DateTime.UtcNow;
        }

        public void ProcessOrder()
        {
            Console.WriteLine($"Processing wash order: Order №{OrderId} for {WashType} wash for {Amount:C}");
        }
    }

    // Абстрактна фабрика для створення замовлень
    public abstract class OrderFactory
    {
        public abstract IWashOrder CreateOrder(string orderId, string washType, decimal amount);
    }

    // Конкретна фабрика для створення замовлень на миття
    public class WashOrderFactory : OrderFactory
    {
        public override IWashOrder CreateOrder(string orderId, string washType, decimal amount)
        {
            return new WashOrder(orderId, washType, amount);
        }
    }
}
