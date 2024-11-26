using CarWashManager.Core.Entities;
using CarWashManager.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace CarWashManager.Infrastructure
{
    public class WashContext : DbContext
    {
        public DbSet<WashEntity> Washs { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }

        public WashContext(DbContextOptions<WashContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WashEntity>()
                .HasKey(w => w.WashId);

            modelBuilder.Entity<TransactionEntity>()
                .HasOne(w => w.Wash)
                .WithMany()
                .HasForeignKey(t => t.WashId);
        }

        public static void Seed(WashContext context)
        {
            context.Washs.AddRange(
                new WashEntity
                {
                    WashId = "1",
                    Price = 25.50m,
                    Type = WashType.FullService,
                    Detergent = "DetergentType1",
                    ServiceName = "Full Service",
                    LastModified = DateTime.Now
                },
                new WashEntity
                {
                    WashId = "2",
                    Price = 40.00m,
                    Type = WashType.ExteriorOnly,
                    Detergent = "DetergentType2",
                    ServiceName = "Exterior Wash",
                    LastModified = DateTime.Now
                },
                new WashEntity
                {
                    WashId = "3",
                    Price = 30.00m,
                    Type = WashType.InteriorOnly,
                    Detergent = "DetergentType3",
                    ServiceName = "Interior Wash",
                    LastModified = DateTime.Now
                });
            context.SaveChanges();
        }
    }
}
