using System;

namespace CarWashManager.Application.Factories
{
    public abstract class WashServiceOrderFactory
    {
        public abstract IWashOrder CreateOrder(string orderId, string washType, decimal amount);
    }
}
