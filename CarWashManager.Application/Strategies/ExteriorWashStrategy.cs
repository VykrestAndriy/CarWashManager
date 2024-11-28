using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;
using System;

namespace CarWashManager.Core.Strategies
{
    public class ExteriorWashStrategy : IWashStrategy
    {
        public void ApplyWash(WashDto wash)
        {
            // Перевіряємо, чи сума менша або дорівнює 70
            if (wash.Amount <= 70)
            {
                // Додаємо 10 до суми за допомогою методу AddAmount
                wash.AddAmount(10);  // Використовуємо AddAmount замість прямого доступу
                Console.WriteLine("Екстер'єрна мийка: додано 10 до суми.");
            }
            else
            {
                Console.WriteLine("Екстер'єрна мийка: сума залишилася незмінною.");
            }
        }
    }
}
