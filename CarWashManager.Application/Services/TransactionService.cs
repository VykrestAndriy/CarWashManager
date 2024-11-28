using CarWashManager.Core.Entities;
using CarWashManager.Infrastructure.RepositoriesWash.Transaction;
using CarWashManager.Core.Contracts;
using CarWashManager.Core.Dtos;
using CarWashManager.Core.Enums;
using CarWashManager.Infrastructure.RepositoriesWash.Wash;

namespace CarWashManager.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IWashRepository _washRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository, IWashRepository washRepository)
        {
            _transactionRepository = transactionRepository;
            _washRepository = washRepository;
        }

        public async Task<IReadOnlyList<TransactionDto>> Get()
        {
            var transactions = await _transactionRepository.Get();
            if (transactions == null)
                return new List<TransactionDto>();

            return transactions.Select(e => new TransactionDto(
                e.TransactionId, e.WashId, e.TransactionType, e.Amount, e.DateTime)).ToList().AsReadOnly();
        }

        public async Task<TransactionDto> Get(string transactionId)
        {
            var transaction = await _transactionRepository.Get(transactionId);
            if (transaction == null)
                return TransactionDto.Default;

            return new TransactionDto(
                transaction.TransactionId, transaction.WashId, transaction.TransactionType, transaction.Amount, transaction.DateTime);
        }

        public async Task<IReadOnlyList<TransactionDto>> GetTodayTransactions()
        {
            var transactions = await _transactionRepository.Get(t => t.DateTime.Date == DateTime.UtcNow.Date);
            if (transactions == null)
                return new List<TransactionDto>();

            return transactions.Select(e => new TransactionDto(
                e.TransactionId, e.WashId, e.TransactionType, e.Amount, e.DateTime)).ToList().AsReadOnly();
        }

        public async Task Create(TransactionDto transaction)
        {
            if (transaction != TransactionDto.Default)
            {
                var wash = await _washRepository.Get(transaction.WashId);

                if (wash == null)
                    throw new ArgumentNullException($"Wash not found by id={transaction.WashId}");

                await _transactionRepository.Create(new TransactionEntity
                {
                    TransactionId = transaction.TransactionId,
                    WashId = transaction.WashId,
                    TransactionType = transaction.Type,
                    Amount = transaction.Amount,
                    DateTime = transaction.TransactionTime
                });

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
        }

        public async Task Remove(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentNullException(nameof(transactionId));

            await _transactionRepository.Delete(transactionId);
        }
    }
}
