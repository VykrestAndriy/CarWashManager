using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class WashServiceDecorator : IWashService
{
    private readonly IWashService _inner;
    private readonly ILogger<WashServiceDecorator> _logger;

    public WashServiceDecorator(IWashService inner, ILogger<WashServiceDecorator> logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public async Task<IReadOnlyList<WashDto>> Get()
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            return await _inner.Get();
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Get washes executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    public async Task<WashDto> Get(string washId)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            return await _inner.Get(washId);
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Get wash by ID {washId} executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    public async Task Add(WashDto wash)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            await _inner.Add(wash);
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Add wash executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    public async Task Update(WashDto wash)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            await _inner.Update(wash);
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Update wash executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    public async Task Remove(string washId)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            await _inner.Remove(washId);
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Remove wash executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    // Реалізація методу GetTransactionById
    public async Task<TransactionDto> GetTransactionById(string transactionId)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            return await _inner.GetTransactionById(transactionId);
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Get transaction by ID {transactionId} executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    // Реалізація методу GetTodayTransactions
    public async Task<IReadOnlyList<TransactionDto>> GetTodayTransactions()
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            return await _inner.GetTodayTransactions();
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Get today's transactions executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    // Реалізація методу GetTransactions
    public async Task<IEnumerable<TransactionDto>> GetTransactions()
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            // Перетворюємо IReadOnlyList на IEnumerable
            return (await _inner.GetTransactions()).ToList();
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Get all transactions executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    // Реалізація методу CreateTransaction
    public async Task CreateTransaction(TransactionDto transaction)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            await _inner.CreateTransaction(transaction); // Викликаємо метод з внутрішнього сервісу
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Create transaction executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    // Реалізація методу RemoveTransaction  
    public async Task RemoveTransaction(string transactionId)
    {
        var stopwatch = Stopwatch.StartNew();
        try
        {
            await _inner.RemoveTransaction(transactionId); // Викликаємо метод з внутрішнього сервісу
        }
        finally
        {
            stopwatch.Stop();
            _logger.LogInformation($"Remove transaction executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
