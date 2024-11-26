using CarWashManager.Core.Enums;
using System.ComponentModel.DataAnnotations;
using CarWashManager.Core.Entities;

namespace CarWashManager.Models.Transactions;

public class CreateTransactionRequest
{
    [Required]
    public string WashId { get; init; }

    [Required]
    public TransactionType TransactionType { get; init; }

    [Required]
    public decimal Amount { get; init; }
}