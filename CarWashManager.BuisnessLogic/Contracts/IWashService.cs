using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWashManager.BusinessLogic.Dtos;

namespace CarWashManager.BusinessLogic.Contracts
{
    public interface IWashService
    {
        Task<IReadOnlyList<WashDto>> Get();  
        Task<TransactionDto> GetTransactionById(string transactionId);  
        Task<IReadOnlyList<TransactionDto>> GetTodayTransactions();  
        Task<WashDto> Get(string washId);  
        Task Add(WashDto wash);  
        Task Update(WashDto wash);  
        Task Remove(string washId);  
        Task<IEnumerable<TransactionDto>> GetTransactions(); 
        Task CreateTransaction(TransactionDto transaction);  
        Task RemoveTransaction(string transactionId);  
    }
}
