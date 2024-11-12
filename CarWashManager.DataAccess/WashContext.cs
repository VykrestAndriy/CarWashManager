using Microsoft.EntityFrameworkCore;
using CarWashManager.DataAccess.Entities;
using CarWashManager.Infrastructure.Enums;

namespace CarWashManager.DataAccess.Entities
{
    // Успадковуємо від DbContext
    public class WashContext : DbContext
    {
        // DbSet для кожної сутності
        public DbSet<WashEntity> Washs { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }

        // Конструктор, який передає опції у базовий клас
        public WashContext(DbContextOptions<WashContext> options) : base(options)
        {
        }

        // Конфігурація моделей
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Тут можна налаштувати додаткові правила для моделі (якщо потрібно)
        }

        // Цей метод для початкових даних не є необхідним для EF, якщо ви використовуєте реальну базу даних
        // Проте ви можете додати ці початкові дані через міграції або вручну
        public static void Seed(WashContext context)
        {
            // Якщо потрібна ініціалізація даних, ви можете це зробити тут
            context.Washs.AddRange(
                new WashEntity
                {
                    WashId = "1",
                    Price = 25.50m,
                    Type = WashType.FullService,
                    LastModified = DateTime.Now
                },
                new WashEntity
                {
                    WashId = "2",
                    Price = 40.00m,
                    Type = WashType.ExteriorOnly,
                    LastModified = DateTime.Now
                },
                new WashEntity
                {
                    WashId = "3",
                    Price = 30.00m,
                    Type = WashType.InteriorOnly,
                    LastModified = DateTime.Now
                });

            context.Transactions.AddRange(
                new TransactionEntity
                {
                    TransactionId = "1",
                    WashId = "1",
                    TransactionType = TransactionType.Successfully,
                    Amount = 1,
                    DateTime = DateTime.Now
                },
                new TransactionEntity
                {
                    TransactionId = "2",
                    WashId = "2",
                    TransactionType = TransactionType.Successfully,
                    Amount = 1,
                    DateTime = DateTime.Now
                },
                new TransactionEntity
                {
                    TransactionId = "3",
                    WashId = "3",
                    TransactionType = TransactionType.Successfully,
                    Amount = 1,
                    DateTime = DateTime.Now
                });

            context.SaveChanges();
        }
    }
}
