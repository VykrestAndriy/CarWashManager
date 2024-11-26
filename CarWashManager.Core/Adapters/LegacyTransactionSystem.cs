namespace CarWashManager.Infrastructure.Legacy
{
    public class LegacyTransactionSystem
    {
        public void PerformTransaction(string washTransactionId, decimal washAmount, string washId)
        {
            if (string.IsNullOrEmpty(washTransactionId) || washAmount <= 0 || string.IsNullOrEmpty(washId))
            {
                throw new ArgumentException("Invalid transaction parameters.");
            }

            // Логіка для обробки транзакції у Legacy системі
            // Симуляція виконання транзакції
            Console.WriteLine($"Legacy system: Performing transaction. Transaction ID: {washTransactionId}, Amount: {washAmount}, Wash ID: {washId}");
        }
    }
}
