using CarWashManager.Core.Dtos;

namespace CarWashManager.Core.Contracts;

public interface ITransactionService
{
    Task<IReadOnlyList<TransactionDto>> Get();
    Task<TransactionDto> Get(string transactionId);
    Task<IReadOnlyList<TransactionDto>> GetTodayTransactions();
    Task Create(TransactionDto transaction);
    Task Remove(string transactionId);
}