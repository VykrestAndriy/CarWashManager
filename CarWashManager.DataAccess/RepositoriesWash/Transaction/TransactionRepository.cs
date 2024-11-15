using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashManager.DataAccess.Entities;
using System.Collections.ObjectModel;

namespace CarWashManager.DataAccess.RepositoriesWash.Transaction;

public class TransactionRepository : ITransactionRepository
{
    private readonly WashContext _context;

    public TransactionRepository(WashContext context)
    {
        _context = context;
    }

    public Task<ReadOnlyCollection<TransactionEntity>> Get() =>
        Task.FromResult(_context.Transactions.ToList().AsReadOnly());

    public Task<TransactionEntity?> Get(string TransactionId) =>
        Task.FromResult(_context.Transactions.FirstOrDefault(e => e.TransactionId == TransactionId));

    public Task<ReadOnlyCollection<TransactionEntity>> Get(Func<TransactionEntity, bool> predicate)
    {
        return Task.FromResult(_context.Transactions.Where(predicate).ToList().AsReadOnly());
    }

    public Task Create(TransactionEntity entity)
    {
        _context.Transactions.Add(entity);
        return Task.CompletedTask;
    }

    public Task Update(TransactionEntity entity)
    {
        foreach (var e in _context.Transactions)
        {
            if (e.TransactionId == entity.TransactionId)
            {
                e.WashId = entity.WashId;
                e.TransactionType = entity.TransactionType;
                e.Amount = entity.Amount;
                e.DateTime = entity.DateTime;
            }
        }
        return Task.CompletedTask;
    }

    public Task Delete(string TransactionId)
    {
        var entity = _context.Transactions.FirstOrDefault(e => e.TransactionId == TransactionId);
        if (entity != null)
        {
            _context.Transactions.Remove(entity);
        }
        return Task.CompletedTask;
    }
}
