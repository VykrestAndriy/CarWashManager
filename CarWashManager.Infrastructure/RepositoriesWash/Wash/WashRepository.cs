using System.Collections.ObjectModel;
using CarWashManager.Core.Entities;

namespace CarWashManager.Infrastructure.RepositoriesWash.Wash;

public class WashRepository : IWashRepository
{
    private readonly WashContext _context;
    public WashRepository(WashContext context)
    {
        _context = context;
    }

    public Task<ReadOnlyCollection<WashEntity>> Get() =>
        Task.FromResult(_context.Washs.ToList().AsReadOnly());

    public Task<WashEntity?> Get(string WashId) =>
        Task.FromResult(_context.Washs.FirstOrDefault(e => e.WashId == WashId));

    public Task<ReadOnlyCollection<WashEntity>> Get(Func<WashEntity, bool> predicate)
    {
        return Task.FromResult(_context.Washs.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(WashEntity entity)
    {
        _context.Washs.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(WashEntity entity)
    {
        foreach (var e in _context.Washs)
        {
            if (e.WashId == entity.WashId)
            {
                e.Type = entity.Type;
                e.Price = entity.Price;
                e.LastModified = DateTime.UtcNow;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string WashId)
    {
        var entity = _context.Washs.FirstOrDefault(e => e.WashId == WashId);
        if (entity != null)
        {
            _context.Washs.Remove(entity);
        }
        return Task.CompletedTask;
    }

    // Реалізація методу GetAllTransactions
    public Task<ReadOnlyCollection<TransactionEntity>> GetAllTransactions()
    {
        // Припустимо, що у вашому контексті є DbSet<TransactionEntity>
        return Task.FromResult(_context.Transactions.ToList().AsReadOnly());
    }

    // Інші методи для роботи з транзакціями
    public Task<TransactionEntity?> GetTransactionById(string transactionId) =>
        Task.FromResult(_context.Transactions.FirstOrDefault(e => e.TransactionId == transactionId));

    public Task CreateTransaction(TransactionEntity transactionEntity)
    {
        _context.Transactions.Add(transactionEntity);
        return Task.CompletedTask;
    }

    public Task DeleteTransaction(string transactionId)
    {
        var entity = _context.Transactions.FirstOrDefault(e => e.TransactionId == transactionId);
        if (entity != null)
        {
            _context.Transactions.Remove(entity);
        }
        return Task.CompletedTask;
    }

    public Task<ReadOnlyCollection<TransactionEntity>> GetTodayTransactions()
    {
        var today = DateTime.UtcNow.Date;
        var transactionsToday = _context.Transactions
            .Where(t => t.TransactionDate.Date == today)
            .ToList()
            .AsReadOnly();

        return Task.FromResult(transactionsToday);
    }
}
