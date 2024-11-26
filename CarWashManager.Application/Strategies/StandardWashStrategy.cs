using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;

public class StandardWashStrategy : IWashStrategy
{
    public void ApplyWash(WashDto wash)
    {
        if (wash.Amount <= 50)
        {
            // Використовуємо метод UpdateAmount для оновлення суми
            wash.UpdateAmount(wash.Amount + 5); // Додаємо 5 до суми
            Console.WriteLine("Стандартна мийка: додано 5 до суми.");
        }
        else
        {
            Console.WriteLine("Стандартна мийка: сума залишилася незмінною.");
        }
    }
}
