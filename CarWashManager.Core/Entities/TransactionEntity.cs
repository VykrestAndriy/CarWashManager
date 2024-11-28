using CarWashManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarWashManager.Core.Entities
{
    public class TransactionEntity
    {
        [Key]
        public string TransactionId { get; init; }
        public string WashId { get; set; }
        public WashEntity Wash { get; set; } 
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
