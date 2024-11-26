namespace CarWashManager.Application.Adapters
{
    public interface IAdapterWashTransactionSystem
    {
        void ProcessWashTransaction(string washTransactionId, decimal washAmount, string washId);
    }
}
