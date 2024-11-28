using CarWashManager.Core.Enums;
using CarWashManager.Core.Entities;
using CarWashManager.Application.Adapters;
using CarWashManager.Infrastructure;

namespace CarWashManager.Core.Adapters
{
    public class TransactionAdapter : IAdapterWashTransactionSystem
    {
        private readonly WashContext _context;

        public TransactionAdapter(WashContext context)
        {
            _context = context;
        }

        public void ProcessWashTransaction(string washTransactionId, decimal washAmount, string washId)
        {
            try
            {
                // Створення транзакції
                var transaction = new TransactionEntity
                {
                    TransactionId = washTransactionId,
                    WashId = washId,  // Пов'язуємо з конкретним миттям
                    TransactionType = TransactionType.Successfully, // Транзакція успішна
                    Amount = washAmount,
                    DateTime = DateTime.UtcNow // Використовуємо UTC час
                };

                // Додаємо транзакцію до контексту
                _context.Transactions.Add(transaction);

                // Створення запису миття
                var wash = new WashEntity
                {
                    WashId = washId,
                    Price = washAmount,
                    Type = WashType.FullService,
                    LastModified = DateTime.UtcNow,  // Використовуємо UTC час
                    Amount = washAmount,
                    ServiceType = ServiceType.ExteriorWash,
                    ServiceName = "Standard Wash",
                    WashTime = DateTime.UtcNow,  // Використовуємо UTC час
                    Detergent = "Soap"
                };

                // Додаємо запис миття до контексту
                _context.Washs.Add(wash);

                // Збереження змін у базі даних
                _context.SaveChanges();

                // Виведення інформації про оброблену транзакцію
                Console.WriteLine($"Processed wash transaction: {washTransactionId}, Amount: {washAmount}, Wash ID: {washId}");
            }
            catch (Exception ex)
            {
                // Логування помилки у разі невдачі
                Console.WriteLine($"Error processing wash transaction: {ex.Message}");
                throw; // Можна кинути виняток далі або обробити по-іншому
            }
        }
    }
}
