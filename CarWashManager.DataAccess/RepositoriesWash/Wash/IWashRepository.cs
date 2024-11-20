using System.Collections.ObjectModel;
using CarWashManager.DataAccess.Entities;

namespace CarWashManager.DataAccess.RepositoriesWash.Wash
{
    public interface IWashRepository
    {
        Task<ReadOnlyCollection<WashEntity>> Get();
        Task<WashEntity?> Get(string WashId);
        Task<ReadOnlyCollection<WashEntity>> Get(Func<WashEntity, bool> predicate);
        Task Create(WashEntity entity);
        Task Update(WashEntity entity);
        Task Delete(string WashId);

        // Додані методи для роботи з транзакціями
        Task<TransactionEntity?> GetTransactionById(string transactionId);
        Task CreateTransaction(TransactionEntity transactionEntity);
        Task DeleteTransaction(string transactionId);
        Task<ReadOnlyCollection<TransactionEntity>> GetTodayTransactions();
        Task<ReadOnlyCollection<TransactionEntity>> GetAllTransactions();
    }
}
