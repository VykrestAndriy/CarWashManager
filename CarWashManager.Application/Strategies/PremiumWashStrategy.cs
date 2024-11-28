using CarWashManager.Core.Dtos;
using CarWashManager.Core.Contracts;

namespace CarWashManager.BusinessLogic.Strategies
{
    public class PremiumWashStrategy : IWashStrategy
    {
        public void ApplyWash(WashDto wash)
        {
            // Логіка преміум мийки
            if (wash.Amount <= 100)
            {
                // Використовуємо метод UpdateAmount для зміни суми
                wash.AddAmount(20); // Додаємо 20 до суми
                Console.WriteLine("Преміум мийка: сума збільшена на 20.");
            }
            else
            {
                Console.WriteLine("Преміум мийка: сума залишилася без змін.");
            }
        }
    }
}
