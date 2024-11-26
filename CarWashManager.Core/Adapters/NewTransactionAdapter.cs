using CarWashManager.Infrastructure.Legacy;
using Microsoft.Extensions.Logging;

namespace CarWashManager.Application.Adapters
{
    public class NewTransactionAdapter : IAdapterWashTransactionSystem
    {
        private readonly NewTransactionSystem _newSystem; 
        private readonly ILogger<NewTransactionAdapter> _logger;

        public NewTransactionAdapter(NewTransactionSystem newSystem, ILogger<NewTransactionAdapter> logger)
        {
            _newSystem = newSystem;
            _logger = logger;
        }

        public void ProcessWashTransaction(string washTransactionId, decimal washAmount, string washId)
        {
            _newSystem.Execute(washId, washAmount);
            _logger.LogInformation($"Processed wash transaction in New System: Wash Transaction ID = {washTransactionId}, Amount = {washAmount}, Wash ID = {washId}");
        }
    }
}
