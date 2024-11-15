using Microsoft.Extensions.Logging;

namespace CarWashManager.BusinessLogic.Adapters
{
    public class AdapterWashTransactionSystem : IAdapterWashTransactionSystem
    {
        private readonly ILogger<AdapterWashTransactionSystem> _logger;

        public AdapterWashTransactionSystem(ILogger<AdapterWashTransactionSystem> logger)
        {
            _logger = logger;
        }

        public void ProcessWashTransaction(string washTransactionId, decimal washAmount, string washId)
        {
            _logger.LogInformation($"Wash Transaction ID: {washTransactionId}, Amount: {washAmount}, Wash ID: {washId}");
        }
    }
}
