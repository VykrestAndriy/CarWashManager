using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashManager.Infrastructure.Enums;

namespace CarWashManager.BusinessLogic.Dtos;

public class TransactionDto : IEquatable<TransactionDto>
{
    public static readonly TransactionDto Default
        = new TransactionDto(string.Empty, string.Empty, TransactionType.Unsuccessfully, decimal.Zero, DateTime.MinValue);

    public string TransactionId { get; }
    public string WashId { get; init; } 
    public TransactionType Type { get; init; }
    public decimal Amount { get; }
    public DateTime TransactionTime { get; } 

    public TransactionDto(string transactionId, string washId, TransactionType type, decimal amount, DateTime transactionTime)
    {
        TransactionId = transactionId;
        WashId = washId; 
        Amount = amount;
        TransactionTime = transactionTime; 
    }

    public bool Equals(TransactionDto? other)
    {
        if (other == null)
            return false;

        return TransactionId == other.TransactionId && WashId == other.WashId && Type == other.Type
            && Amount == other.Amount && TransactionTime == other.TransactionTime; 
    }

    public override int GetHashCode()
    {
        return (TransactionId.GetHashCode() + WashId.GetHashCode() + Type.GetHashCode()
            + Amount.GetHashCode() + TransactionTime.GetHashCode()) * 45; 
    }
}
