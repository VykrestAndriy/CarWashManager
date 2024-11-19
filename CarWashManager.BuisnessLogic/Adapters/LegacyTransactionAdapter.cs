using Microsoft.Extensions.Logging;
using CarWashManager.DataAccess.Legacy; // Додайте правильний простір імен для LegacyTransactionSystem

namespace CarWashManager.BusinessLogic.Adapters
{
    public class LegacyTransactionAdapter : IAdapterWashTransactionSystem
    {
        private readonly LegacyTransactionSystem _legacySystem; // Ваш клас LegacyTransactionSystem
        private readonly ILogger<LegacyTransactionAdapter> _logger;

        public LegacyTransactionAdapter(LegacyTransactionSystem legacySystem, ILogger<LegacyTransactionAdapter> logger)
        {
            _legacySystem = legacySystem;
            _logger = logger;
        }

        public void ProcessWashTransaction(string washTransactionId, decimal washAmount, string washId)
        {
            _legacySystem.PerformTransaction(washTransactionId, washAmount, washId); // Викликаємо метод для транзакції
            _logger.LogInformation($"Processed wash transaction in Legacy System: Wash Transaction ID = {washTransactionId}, Amount = {washAmount}, Wash ID = {washId}");
        }
    }
}
