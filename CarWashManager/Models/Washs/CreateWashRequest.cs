using System.ComponentModel.DataAnnotations;
using CarWashManager.Infrastructure.Enums;

namespace CarWashManager.Models.Washs;

public class CreateWashRequest
{
    public string TransactionId { get; set; }
    public WashType WashType { get; set; }
    public string Detergent { get; set; }
    public ServiceType ServiceType { get; set; }  
    public string ServiceName { get; set; }
    public decimal Amount { get; set; }
    public DateTime WashTime { get; set; }
    public string WashId { get; set; }      
    public TransactionType TransactionType { get; set; }
}

