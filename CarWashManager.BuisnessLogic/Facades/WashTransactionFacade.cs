using CarWashManager.BusinessLogic.Dtos;
using CarWashManager.BusinessLogic.Services;
using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.DataAccess.RepositoriesWash.Wash;
using CarWashManager.Infrastructure.Enums;

namespace CarWashManager.BuisnessLogic.Facades;

public class WashTransactionFacade
{
    private readonly ITransactionService _transactionService;
    private readonly IWashRepository _washRepository;

    public WashTransactionFacade(ITransactionService transactionService, IWashRepository washRepository)
    {
        _transactionService = transactionService;
        _washRepository = washRepository;
    }

    public async Task CreateTransactionAndUpdateWash(TransactionDto transaction)
    {
        var wash = await _washRepository.Get(transaction.WashId);

        if (wash == null)
            throw new ArgumentNullException($"Wash not found by ID = {transaction.WashId}");

        await _transactionService.Create(transaction);

        switch (transaction.Type)
        {
            case TransactionType.Successfully:
                wash.Amount += transaction.Amount;
                break;
            case TransactionType.Unsuccessfully:
                wash.Amount -= transaction.Amount;
                break;
        }

        await _washRepository.Update(wash);
    }

    public async Task RemoveTransactionAndUpdateWash(string transactionId)
    {
        var transaction = await _transactionService.Get(transactionId);

        if (transaction == null || transaction == TransactionDto.Default)
            throw new ArgumentNullException($"Transaction not found by ID = {transactionId}");

        var wash = await _washRepository.Get(transaction.WashId);

        if (wash == null)
            throw new ArgumentNullException($"Wash not found by ID = {transaction.WashId}");

        await _transactionService.Remove(transactionId);

        switch (transaction.Type)
        {
            case TransactionType.Successfully:
                wash.Amount -= transaction.Amount;
                break;
            case TransactionType.Unsuccessfully:
                wash.Amount += transaction.Amount;
                break;
        }

        await _washRepository.Update(wash);
    }
}
