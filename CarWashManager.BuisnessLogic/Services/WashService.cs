using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Dtos;
using CarWashManager.DataAccess.Entities;
using CarWashManager.DataAccess.RepositoriesWash.Wash;
using CarWashManager.Infrastructure.Enums;
using CarWashManager.BusinessLogic.Services;
using CarWashManager.BusinessLogic.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashManager.BusinessLogic.Services
{
    public class WashService : IWashService
    {
        private readonly IWashRepository _washRepository;

        public WashService(IWashRepository washRepository)
        {
            _washRepository = washRepository;
        }

        public async Task<IReadOnlyList<WashDto>> Get()
        {
            var washes = await _washRepository.Get();
            if (washes == null)
                return new List<WashDto>();

            return washes.Select(e => new WashDto(
                washId: e.WashId,
                washType: e.Type,
                detergent: e.Detergent,
                serviceType: e.ServiceType,
                serviceName: e.ServiceName,
                amount: e.Amount,
                washTime: e.WashTime,
                startTime: DateTime.UtcNow
            )).ToList().AsReadOnly();
        }

        public async Task<WashDto> Get(string washId)
        {
            var wash = await _washRepository.Get(washId);
            if (wash == null)
                return WashDto.Default;

            return new WashDto(
                washId: wash.WashId,
                washType: wash.Type,
                detergent: wash.Detergent,
                serviceType: wash.ServiceType,
                serviceName: wash.ServiceName,
                amount: wash.Amount,
                washTime: wash.WashTime,
                startTime: DateTime.UtcNow
            );
        }

        public async Task Add(WashDto wash)
        {
            if (wash == WashDto.Default)
                return;

            await _washRepository.Create(new WashEntity
            {
                WashId = wash.WashId,
                Type = wash.WashType,
                ServiceType = wash.ServiceType,
                ServiceName = wash.ServiceName,
                Amount = wash.Amount,
                WashTime = DateTime.UtcNow
            });
        }

        public async Task Update(WashDto wash)
        {
            if (wash == WashDto.Default)
                return;

            await _washRepository.Update(new WashEntity
            {
                WashId = wash.WashId,
                Type = wash.WashType,
                ServiceType = wash.ServiceType,
                ServiceName = wash.ServiceName,
                Amount = wash.Amount,
                WashTime = DateTime.UtcNow
            });
        }

        public async Task Remove(string washId)
        {
            if (string.IsNullOrEmpty(washId))
                throw new ArgumentNullException(nameof(washId));

            await _washRepository.Delete(washId);
        }

        public async Task RemoveTransaction(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentNullException(nameof(transactionId));

            await _washRepository.DeleteTransaction(transactionId);
        }

        public async Task CreateTransaction(TransactionDto transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            var transactionEntity = new TransactionEntity
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                ServiceName = transaction.ServiceName,
                ServiceType = transaction.ServiceType,
                TransactionDate = DateTime.UtcNow
            };

            await _washRepository.CreateTransaction(transactionEntity);
        }

        public async Task<WashDto> CloneWash(string washId)
        {
            var existingWash = await _washRepository.Get(washId);
            if (existingWash == null)
                throw new InvalidOperationException($"Wash with Id {washId} not found.");

            var clonedWash = new WashDto(
                washId: Guid.NewGuid().ToString(),
                washType: existingWash.Type,
                detergent: existingWash.Detergent,
                serviceType: existingWash.ServiceType,
                serviceName: existingWash.ServiceName,
                amount: existingWash.Amount,
                washTime: existingWash.WashTime,
                startTime: DateTime.UtcNow
            );

            await _washRepository.Create(new WashEntity
            {
                WashId = clonedWash.WashId,
                Type = clonedWash.WashType,
                ServiceType = clonedWash.ServiceType,
                ServiceName = clonedWash.ServiceName,
                Amount = clonedWash.Amount,
                WashTime = clonedWash.WashTime
            });

            return clonedWash;
        }

        public async Task<TransactionDto> GetTransactionById(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentNullException(nameof(transactionId));

            var transaction = await _washRepository.GetTransactionById(transactionId);
            if (transaction == null)
                return TransactionDto.Default;

            return new TransactionDto(
                transaction.TransactionId,
                transaction.WashId,
                transaction.TransactionType,
                transaction.Amount,
                transaction.TransactionDate
            );
        }

        public async Task<IReadOnlyList<TransactionDto>> GetTodayTransactions()
        {
            var todayTransactions = await _washRepository.GetTodayTransactions();
            if (todayTransactions == null)
                return new List<TransactionDto>();

            return todayTransactions.Select(t => new TransactionDto(
                transactionId: t.TransactionId,
                washId: t.WashId,
                type: t.TransactionType,
                amount: t.Amount,
                transactionTime: t.TransactionDate
            )).ToList().AsReadOnly();
        }

        public async Task<IEnumerable<TransactionDto>> GetTransactions()
        {
            var transactions = await _washRepository.GetAllTransactions();
            if (transactions == null)
                return new List<TransactionDto>();

            return transactions.Select(t =>
            {
                if (Enum.TryParse(t.ServiceType, out TransactionType serviceType))
                {
                    return new TransactionDto(
                        t.TransactionId,
                        t.ServiceName,
                        serviceType,
                        t.Amount,
                        t.TransactionDate
                    );
                }
                else
                {
                    throw new InvalidOperationException($"Invalid ServiceType value: {t.ServiceType}");
                }
            });
        }

        // Додано метод для перевірок перед додаванням
        public async Task AddWithChecks(WashDto wash)
        {
            if (wash == WashDto.Default)
                return;

            // Створюємо ланцюг обробників
            var handler = new AmountCheckHandler();
            handler.SetNext(new DiscountCheckHandler());

            // Перевіряємо за допомогою обробників
            await handler.HandleRequest(wash);

            // Додаємо після перевірки
            await _washRepository.Create(new WashEntity
            {
                WashId = wash.WashId,
                Type = wash.WashType,
                ServiceType = wash.ServiceType,
                ServiceName = wash.ServiceName,
                Amount = wash.Amount,
                WashTime = DateTime.UtcNow
            });
        }
    }
}
