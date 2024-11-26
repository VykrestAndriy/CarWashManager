using CarWashManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarWashManager.Core.Entities
{
    public class WashEntity
    {
        [Key]
        public string WashId { get; init; }
        public decimal Price { get; set; }

        public WashType Type { get; set; }

        public DateTime LastModified { get; set; }
        public decimal Amount { get; set; }
        public ServiceType ServiceType { get; set; }
        public string ServiceName { get; set; }
        public DateTime WashTime { get; set; }
        public string Detergent { get; set; }
    }
}
