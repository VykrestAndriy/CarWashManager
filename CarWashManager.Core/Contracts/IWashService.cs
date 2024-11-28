using CarWashManager.Core.Dtos;

public interface IWashService
{
    Task<WashDto> GetWashByIdAsync(Guid washId);  
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
    Task CreateWashAsync(WashDto washDto);
    Task<IEnumerable<WashDto>> GetAllWashesAsync();
    Task UpdateWashAsync(object existingWash);
}
