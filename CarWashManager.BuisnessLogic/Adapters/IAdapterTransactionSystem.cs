namespace CarWashManager.BusinessLogic.Adapters
{
    public interface IAdapterWashTransactionSystem
    {
        void ProcessWashTransaction(string washTransactionId, decimal washAmount, string washId);
    }
}
