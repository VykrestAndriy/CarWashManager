using Microsoft.EntityFrameworkCore;
using CarWashManager.DataAccess.Entities;
using CarWashManager.Infrastructure.Enums;

namespace CarWashManager.DataAccess.Entities
{
    public class WashContext : DbContext
    {
        public DbSet<WashEntity> Washs { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }

        public static void Seed(WashContext context)
        {
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
