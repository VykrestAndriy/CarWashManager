using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashManager.BusinessLogic.Dtos;

namespace CarWashManager.BusinessLogic.Contracts;

public interface ITransactionService
{
    Task<IReadOnlyList<TransactionDto>> Get();
    Task<TransactionDto> Get(string transactionId);
    Task<IReadOnlyList<TransactionDto>> GetTodayTransactions();
    Task Create(TransactionDto transaction);
    Task Remove(string transactionId);
}