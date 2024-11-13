using System;

namespace CarWashManager.BuisnessLogic.Factories
{
    public abstract class WashServiceOrderFactory
    {
        public abstract IWashOrder CreateOrder(string orderId, string washType, decimal amount);
    }
}
