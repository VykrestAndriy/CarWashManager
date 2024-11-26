using System;
using CarWashManager.Core.Enums;

namespace CarWashManager.Core.Dtos
{
    public class TransactionDto : IEquatable<TransactionDto>
    {
        public static readonly TransactionDto Default
            = new TransactionDto(string.Empty, string.Empty, TransactionType.Unsuccessfully, decimal.Zero, DateTime.MinValue);

        public string TransactionId { get; }
        public string WashId { get; init; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public TransactionType Type { get; init; }
        public decimal Amount { get; }
        public DateTime TransactionTime { get; }

        public TransactionDto(string transactionId, string washId, TransactionType type, decimal amount, DateTime transactionTime)
        {
            TransactionId = transactionId ?? throw new ArgumentNullException(nameof(transactionId)); // Перевірка на null для строк
            WashId = washId ?? throw new ArgumentNullException(nameof(washId)); // Перевірка на null для строк
            Type = type;
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
}
