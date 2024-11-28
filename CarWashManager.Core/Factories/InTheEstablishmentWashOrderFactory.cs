using CarWashManager.Core.Enums;

namespace CarWashManager.Application.Factories
{
    // Клас для замовлення миття на місці
    public class InTheEstablishmentWashOrder : IWashOrder
    {
        public string OrderId { get; private set; }
        public string WashType { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime OrderTime { get; private set; }

        public InTheEstablishmentWashOrder(string orderId, string washType, decimal amount)
        {
            OrderId = orderId;
            WashType = washType;
            Amount = amount;
            OrderTime = DateTime.UtcNow;
        }

        public void ProcessOrder()
        {
            Console.WriteLine($"Processing in the establishment wash order: order №{OrderId} - {WashType} wash for {Amount:C}");
        }
    }

    // Фабрика для створення замовлень на миття на місці
    public class InTheEstablishmentWashOrderFactory : WashOrderFactory
    {
        public override IWashOrder CreateOrder(string orderId, string washType, decimal amount)
        {
            return new InTheEstablishmentWashOrder(orderId, washType, amount);
        }
    }
}
