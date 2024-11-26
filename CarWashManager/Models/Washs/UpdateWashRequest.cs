using System.ComponentModel.DataAnnotations;
using CarWashManager.Core.Enums;

namespace CarWashManager.Models.Washs
{
    public class UpdateWashRequest
    {
        [Required]
        public string WashId { get; init; }

        [Required]
        public WashType WashType { get; init; }

        [Required]
        public string Detergent { get; init; }

        [Required]
        public ServiceType ServiceType { get; init; }

        [Required]
        public string ServiceName { get; init; }

        [Required]
        public DateTime WashTime { get; init; }

        [Required]
        public decimal Amount { get; init; }
    }
}
