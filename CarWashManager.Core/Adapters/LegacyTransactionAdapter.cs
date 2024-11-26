using Microsoft.Extensions.Logging;
using CarWashManager.Infrastructure.Legacy; 

namespace CarWashManager.Application.Adapters
{
    public class LegacyTransactionAdapter : IAdapterWashTransactionSystem
    {
        private readonly LegacyTransactionSystem _legacySystem; 
        private readonly ILogger<LegacyTransactionAdapter> _logger;

        public LegacyTransactionAdapter(LegacyTransactionSystem legacySystem, ILogger<LegacyTransactionAdapter> logger)
        {
            _legacySystem = legacySystem;
            _logger = logger;
        }

        public void ProcessWashTransaction(string washTransactionId, decimal washAmount, string washId)
        {
            _legacySystem.PerformTransaction(washTransactionId, washAmount, washId); 
            _logger.LogInformation($"Processed wash transaction in Legacy System: Wash Transaction ID = {washTransactionId}, Amount = {washAmount}, Wash ID = {washId}");
        }
    }
}
